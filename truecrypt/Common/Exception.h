/*
 Copyright (c) 2008 TrueCrypt Developers Association. All rights reserved.

 Governed by the TrueCrypt License 3.0 the full text of which is contained in
 the file License.txt included in TrueCrypt binary and source code distribution
 packages.
*/

#ifndef TC_HEADER_Common_Exception
#define TC_HEADER_Common_Exception

#include "Platform/PlatformBase.h"

namespace TrueCrypt
{
	struct Exception 
	{
	};

	struct SystemException : public Exception
	{
		SystemException () : ErrorCode (GetLastError()) { }
		DWORD ErrorCode;
	};

	struct ErrorException : public Exception
	{
		ErrorException (char *langId) : ErrLangId (langId) { }
		ErrorException (const wstring &errMsg) : ErrMsg (errMsg) { }

		char *ErrLangId;
		wstring ErrMsg;
	};

	struct ParameterIncorrect : public Exception
	{
		ParameterIncorrect (const char *srcPos) : SrcPos (srcPos) { }

		const char *SrcPos;
	};

	struct TimeOut : public Exception
	{
		TimeOut (const char *srcPos) { }
		//void Show (HWND parent) const { ErrorDirect (L"Timeout"); }
	};

	struct UserAbort : public Exception
	{
		UserAbort (const char *srcPos) { }
	};
}

#define throw_sys_if(condition) do { if (condition) throw SystemException(); } while (false)


#endif // TC_HEADER_Common_Exception
