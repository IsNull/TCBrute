using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecryptbrute.truecrypt
{
    public enum TCErrorCode : int
    {
        ERR_SUCCESS = 0,
        ERR_OS_ERROR = 1,
        ERR_OUTOFMEMORY = 2,
        ERR_PASSWORD_WRONG = 3,
        ERR_VOL_FORMAT_BAD = 4,
        ERR_DRIVE_NOT_FOUND = 5,
        ERR_FILES_OPEN = 6,
        ERR_VOL_SIZE_WRONG = 7,
        ERR_COMPRESSION_NOT_SUPPORTED = 8,
        ERR_PASSWORD_CHANGE_VOL_TYPE = 9,
        ERR_PASSWORD_CHANGE_VOL_VERSION = 10,
        ERR_VOL_SEEKING = 11,
        ERR_VOL_WRITING = 12,
        ERR_FILES_OPEN_LOCK = 13,
        ERR_VOL_READING = 14,
        ERR_DRIVER_VERSION = 15,
        ERR_NEW_VERSION_REQUIRED = 16,
        ERR_CIPHER_INIT_FAILURE = 17,
        ERR_CIPHER_INIT_WEAK_KEY = 18,
        ERR_SELF_TESTS_FAILED = 19,
        ERR_SECTOR_SIZE_INCOMPATIBLE = 20,
        ERR_VOL_ALREADY_MOUNTED = 21,
        ERR_NO_FREE_DRIVES = 22,
        ERR_FILE_OPEN_FAILED = 23,
        ERR_VOL_MOUNT_FAILED = 24,
        DEPRECATED_ERR_INVALID_DEVICE = 25,
        ERR_ACCESS_DENIED = 26,
        ERR_MODE_INIT_FAILED = 27,
        ERR_DONT_REPORT = 28,
        ERR_ENCRYPTION_NOT_COMPLETED = 29,
        ERR_PARAMETER_INCORRECT = 30,
        ERR_SYS_HIDVOL_HEAD_REENC_MODE_WRONG = 31,
        ERR_NONSYS_INPLACE_ENC_INCOMPLETE = 32,
        ERR_USER_ABORT = 33
    }

    class TCException : Exception
    {
        public TCException(TCErrorCode err) {
            ErrorCode = err;
        }

        public TCErrorCode ErrorCode;
    }
}
