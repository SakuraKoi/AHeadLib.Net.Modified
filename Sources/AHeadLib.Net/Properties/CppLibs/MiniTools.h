// generated by tools
// AHeadLib.Net
// https://github.com/bodong1987/AHeadLib.Net
// Powered by bodong

#pragma once

#include <windows.h>
#include <Psapi.h>

#ifdef  __cplusplus

#ifndef G_BEGIN_DECLS
# define G_BEGIN_DECLS  extern "C" {
#endif

#ifndef G_END_DECLS
# define G_END_DECLS    }
#endif

#else

#ifndef G_BEGIN_DECLS
# define G_BEGIN_DECLS
#endif

#ifndef G_END_DECLS
# define G_END_DECLS
#endif

#endif

// if you want to disable error report by message box
// change DISABLE_REPORT_ERROR_BY_MESSAGEBOX to 1
#define DISABLE_REPORT_ERROR_BY_MESSAGEBOX 0

#if DISABLE_REPORT_ERROR_BY_MESSAGEBOX
#define ShowMessageBox(...) 
#else
#define ShowMessageBox(...) MessageBox(__VA_ARGS__)
#endif

G_BEGIN_DECLS
BOOL ReplaceMemory(void* dest, const void* source, int length);
BOOL FindModuleSection(HMODULE module, const char* segmentName, void** outSectionStart, LONGLONG* outSize);
void* SearchInSection(HMODULE module, const char* segmentName, const void* signature, int length);
void* SearchInMemory(const void* startPos, const void* endPos, const void* signature, int length);
BOOL PatchMemory(HMODULE module, const char* segmentName, const void* signature, const void* newBytes, int length);
BOOL PatchMultipleMemories(HMODULE module, const char* segmentName, const void** signaturePtr, const void** newBytesPtr, int* lengthPtr, int count);
G_END_DECLS