/*
 Legal Notice: Some portions of the source code contained in this file were
 derived from the source code of Encryption for the Masses 2.02a, which is
 Copyright (c) 1998-2000 Paul Le Roux and which is governed by the 'License
 Agreement for Encryption for the Masses'. Modifications and additions to
 the original source code (contained in this file) and all other portions
 of this file are Copyright (c) 2003-2010 TrueCrypt Developers Association
 and are governed by the TrueCrypt License 3.0 the full text of which is
 contained in the file License.txt included in TrueCrypt binary and source
 code distribution packages. */

#include "Tcdefs.h"

#ifndef TC_WINDOWS_BOOT
#include <fcntl.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <time.h>
#include "EncryptionThreadPool.h"
#endif

#include <stddef.h>
#include <string.h>
#include <io.h>

/*
#ifndef DEVICE_DRIVER
#include "Random.h"
#endif*/

#include "Crc.h"
#include "Crypto.h"
#include "Endian.h"
#include "Volumes.h"
#include "Pkcs5.h"


/* Volume header v5 structure (used since TrueCrypt 7.0): */
//
// Offset	Length	Description
// ------------------------------------------
// Unencrypted:
// 0		64		Salt
// Encrypted:
// 64		4		ASCII string 'TRUE'
// 68		2		Header version
// 70		2		Required program version
// 72		4		CRC-32 checksum of the (decrypted) bytes 256-511
// 76		8		Reserved (set to zero)
// 84		8		Reserved (set to zero)
// 92		8		Size of hidden volume in bytes (0 = normal volume)
// 100		8		Size of the volume in bytes (identical with field 92 for hidden volumes, valid if field 70 >= 0x600 or flag bit 0 == 1)
// 108		8		Byte offset of the start of the master key scope (valid if field 70 >= 0x600 or flag bit 0 == 1)
// 116		8		Size of the encrypted area within the master key scope (valid if field 70 >= 0x600 or flag bit 0 == 1)
// 124		4		Flags: bit 0 set = system encryption; bit 1 set = non-system in-place encryption, bits 2-31 are reserved (set to zero)
// 128		4		Sector size in bytes
// 132		120		Reserved (set to zero)
// 252		4		CRC-32 checksum of the (decrypted) bytes 64-251
// 256		256		Concatenated primary master key(s) and secondary master key(s) (XTS mode)




uint16 GetHeaderField16 (byte *header, int offset)
{
	return BE16 (*(uint16 *) (header + offset));
}


uint32 GetHeaderField32 (byte *header, int offset)
{
	return BE32 (*(uint32 *) (header + offset));
}


UINT64_STRUCT GetHeaderField64 (byte *header, int offset)
{
	UINT64_STRUCT uint64Struct;

#ifndef TC_NO_COMPILER_INT64
	uint64Struct.Value = BE64 (*(uint64 *) (header + offset));
#else
	uint64Struct.HighPart = BE32 (*(uint32 *) (header + offset));
	uint64Struct.LowPart = BE32 (*(uint32 *) (header + offset + 4));
#endif
	return uint64Struct;
}


typedef struct
{
	char DerivedKey[MASTER_KEYDATA_SIZE];
	BOOL Free;
	LONG KeyReady;
	int Pkcs5Prf;
} KeyDerivationWorkItem;


BOOL ReadVolumeHeaderRecoveryMode = FALSE;

///
///	Note: if there are Keyfiles, these must be applied already to the password!
/// int __declspec(dllexport)  __stdcall  CheckVolumeHeaderPassword (BOOL bBoot, char *encryptedHeader, Password *password) 
int __declspec(dllexport)  __cdecl  CheckVolumeHeaderPassword (BOOL bBoot, char *encryptedHeader, Password *password)
{
	char header[TC_VOLUME_HEADER_EFFECTIVE_SIZE];
	KEY_INFO keyInfo;
	PCRYPTO_INFO cryptoInfo;
	char dk[MASTER_KEYDATA_SIZE];
	int enqPkcs5Prf, pkcs5_prf;
	uint16 headerVersion;
	int status = ERR_PARAMETER_INCORRECT;
	int primaryKeyOffset;

	TC_EVENT keyDerivationCompletedEvent;
	TC_EVENT noOutstandingWorkItemEvent;
	KeyDerivationWorkItem *keyDerivationWorkItems;
	KeyDerivationWorkItem *item;
	int pkcs5PrfCount = LAST_PRF_ID - FIRST_PRF_ID + 1;
	size_t encryptionThreadCount = GetEncryptionThreadCount();
	size_t queuedWorkItems = 0;
	LONG outstandingWorkItemCount = 0;
	int i;

	cryptoInfo = crypto_open();
	if (cryptoInfo == NULL)
		return ERR_OUTOFMEMORY;


	if (encryptionThreadCount > 1)
	{
		keyDerivationWorkItems = TCalloc (sizeof (KeyDerivationWorkItem) * pkcs5PrfCount);
		if (!keyDerivationWorkItems)
			return ERR_OUTOFMEMORY;

		for (i = 0; i < pkcs5PrfCount; ++i)
			keyDerivationWorkItems[i].Free = TRUE;


		keyDerivationCompletedEvent = CreateEvent (NULL, FALSE, FALSE, NULL);
		if (!keyDerivationCompletedEvent)
		{
			TCfree (keyDerivationWorkItems);
			return ERR_OUTOFMEMORY;
		}

		noOutstandingWorkItemEvent = CreateEvent (NULL, FALSE, TRUE, NULL);
		if (!noOutstandingWorkItemEvent)
		{
			CloseHandle (keyDerivationCompletedEvent);
			TCfree (keyDerivationWorkItems);
			return ERR_OUTOFMEMORY;
		}
	}
		

	VirtualLock (&keyInfo, sizeof (keyInfo));
	VirtualLock (&dk, sizeof (dk));

	crypto_loadkey (&keyInfo, password->Text, (int) password->Length);

	// PKCS5 is used to derive the primary header key(s) and secondary header key(s) (XTS mode) from the password
	memcpy (keyInfo.salt, encryptedHeader + HEADER_SALT_OFFSET, PKCS5_SALT_SIZE);

	// Test all available PKCS5 PRFs
	for (enqPkcs5Prf = FIRST_PRF_ID; enqPkcs5Prf <= LAST_PRF_ID || queuedWorkItems > 0; ++enqPkcs5Prf)
	{
		BOOL lrw64InitDone = FALSE;		// Deprecated/legacy
		BOOL lrw128InitDone = FALSE;	// Deprecated/legacy

		if (encryptionThreadCount > 1)
		{
			// Enqueue key derivation on thread pool
			if (queuedWorkItems < encryptionThreadCount && enqPkcs5Prf <= LAST_PRF_ID)
			{
				for (i = 0; i < pkcs5PrfCount; ++i)
				{
					item = &keyDerivationWorkItems[i];
					if (item->Free)
					{
						item->Free = FALSE;
						item->KeyReady = FALSE;
						item->Pkcs5Prf = enqPkcs5Prf;

						EncryptionThreadPoolBeginKeyDerivation (&keyDerivationCompletedEvent, &noOutstandingWorkItemEvent,
							&item->KeyReady, &outstandingWorkItemCount, enqPkcs5Prf, keyInfo.userKey,
							keyInfo.keyLength, keyInfo.salt, get_pkcs5_iteration_count (enqPkcs5Prf, bBoot), item->DerivedKey);
						
						++queuedWorkItems;
						break;
					}
				}

				if (enqPkcs5Prf < LAST_PRF_ID)
					continue;
			}
			else
				--enqPkcs5Prf;

			// Wait for completion of a key derivation
			while (queuedWorkItems > 0)
			{
				for (i = 0; i < pkcs5PrfCount; ++i)
				{
					item = &keyDerivationWorkItems[i];
					if (!item->Free && InterlockedExchangeAdd (&item->KeyReady, 0) == TRUE)
					{
						pkcs5_prf = item->Pkcs5Prf;
						keyInfo.noIterations = get_pkcs5_iteration_count (pkcs5_prf, bBoot);
						memcpy (dk, item->DerivedKey, sizeof (dk));

						item->Free = TRUE;
						--queuedWorkItems;
						goto KeyReady;
					}
				}

				if (queuedWorkItems > 0)
					TC_WAIT_EVENT (keyDerivationCompletedEvent);
			}
			continue;
KeyReady:	;
		}
		else
		{
			pkcs5_prf = enqPkcs5Prf;
			keyInfo.noIterations = get_pkcs5_iteration_count (enqPkcs5Prf, bBoot);

			switch (pkcs5_prf)
			{
			case RIPEMD160:
				derive_key_ripemd160 (keyInfo.userKey, keyInfo.keyLength, keyInfo.salt,
					PKCS5_SALT_SIZE, keyInfo.noIterations, dk, GetMaxPkcs5OutSize());
				break;

			case SHA512:
				derive_key_sha512 (keyInfo.userKey, keyInfo.keyLength, keyInfo.salt,
					PKCS5_SALT_SIZE, keyInfo.noIterations, dk, GetMaxPkcs5OutSize());
				break;

			case SHA1:
				// Deprecated/legacy
				derive_key_sha1 (keyInfo.userKey, keyInfo.keyLength, keyInfo.salt,
					PKCS5_SALT_SIZE, keyInfo.noIterations, dk, GetMaxPkcs5OutSize());
				break;

			case WHIRLPOOL:
				derive_key_whirlpool (keyInfo.userKey, keyInfo.keyLength, keyInfo.salt,
					PKCS5_SALT_SIZE, keyInfo.noIterations, dk, GetMaxPkcs5OutSize());
				break;

			default:		
				// Unknown/wrong ID
				TC_THROW_FATAL_EXCEPTION;
			} 
		}

		// Test all available modes of operation
		for (cryptoInfo->mode = FIRST_MODE_OF_OPERATION_ID;
			cryptoInfo->mode <= LAST_MODE_OF_OPERATION;
			cryptoInfo->mode++)
		{
			switch (cryptoInfo->mode)
			{
			case LRW:
			case CBC:
			case INNER_CBC:
			case OUTER_CBC:

				// For LRW (deprecated/legacy), copy the tweak key 
				// For CBC (deprecated/legacy), copy the IV/whitening seed 
				memcpy (cryptoInfo->k2, dk, LEGACY_VOL_IV_SIZE);
				primaryKeyOffset = LEGACY_VOL_IV_SIZE;
				break;

			default:
				primaryKeyOffset = 0;
			}

			// Test all available encryption algorithms
			for (cryptoInfo->ea = EAGetFirst ();
				cryptoInfo->ea != 0;
				cryptoInfo->ea = EAGetNext (cryptoInfo->ea))
			{
				int blockSize;

				if (!EAIsModeSupported (cryptoInfo->ea, cryptoInfo->mode))
					continue;	// This encryption algorithm has never been available with this mode of operation

				blockSize = CipherGetBlockSize (EAGetFirstCipher (cryptoInfo->ea));

				status = EAInit (cryptoInfo->ea, dk + primaryKeyOffset, cryptoInfo->ks);
				if (status == ERR_CIPHER_INIT_FAILURE)
					goto err;

				// Init objects related to the mode of operation

				if (cryptoInfo->mode == XTS)
				{
					// Copy the secondary key (if cascade, multiple concatenated)
					memcpy (cryptoInfo->k2, dk + EAGetKeySize (cryptoInfo->ea), EAGetKeySize (cryptoInfo->ea));

					// Secondary key schedule
					if (!EAInitMode (cryptoInfo))
					{
						status = ERR_MODE_INIT_FAILED;
						goto err;
					}
				}
				else if (cryptoInfo->mode == LRW
					&& (blockSize == 8 && !lrw64InitDone || blockSize == 16 && !lrw128InitDone))
				{
					// Deprecated/legacy

					if (!EAInitMode (cryptoInfo))
					{
						status = ERR_MODE_INIT_FAILED;
						goto err;
					}

					if (blockSize == 8)
						lrw64InitDone = TRUE;
					else if (blockSize == 16)
						lrw128InitDone = TRUE;
				}

				// Copy the header for decryption
				memcpy (header, encryptedHeader, sizeof (header));

				// Try to decrypt header 

				DecryptBuffer (header + HEADER_ENCRYPTED_DATA_OFFSET, HEADER_ENCRYPTED_DATA_SIZE, cryptoInfo);

				// Magic 'TRUE'
				if (GetHeaderField32 (header, TC_HEADER_OFFSET_MAGIC) == 0x54525545){
					status = ERR_SUCCESS;
					goto ret;
				}
			}
		}
	}
	status = ERR_PASSWORD_WRONG;

err:
ret:
	burn (&keyInfo, sizeof (keyInfo));
	burn (dk, sizeof(dk));

	VirtualUnlock (&keyInfo, sizeof (keyInfo));
	VirtualUnlock (&dk, sizeof (dk));

	if (encryptionThreadCount > 1)
	{
	//	TC_WAIT_EVENT (noOutstandingWorkItemEvent);

		burn (keyDerivationWorkItems, sizeof (KeyDerivationWorkItem) * pkcs5PrfCount);
		TCfree (keyDerivationWorkItems);

		CloseHandle (keyDerivationCompletedEvent);
		CloseHandle (noOutstandingWorkItemEvent);
	}

	return status;
}



