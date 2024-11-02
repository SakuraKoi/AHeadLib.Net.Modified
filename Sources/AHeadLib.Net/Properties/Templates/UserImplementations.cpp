// @generated
// AHeadLib.Net
// https://github.com/SakuraKoi/AHeadLib.Net
// Powered by bodong | Modified by.SakuraKooi

#include <Windows.h>
#include <cassert>
#include <tchar.h>

#define STRINGIFY(x) #x
#define TO_STRING(x) STRINGIFY(x)

#define MESSAGE_RAISE_LOCATION __FILE__ "(" TO_STRING(__LINE__) "): "

// fill original library path here
// use absolute file path
void GetOriginalLibraryPath(TCHAR* bufferPtr, int bufferLength, const TCHAR* libName) {
    assert(bufferPtr != nullptr);
    assert(libName != nullptr);

    // By default, the path of the original Library is considered to be the system directory. 
    // If you need another path, be sure to modify the code here and replace it with the correct location.
#pragma message(MESSAGE_RAISE_LOCATION "If you need to adjust the absolute path of the original library file, please modify this.") // NOLINT(clang-diagnostic-#pragma-messages)

    GetSystemDirectory(bufferPtr, bufferLength);
    lstrcat(bufferPtr, TEXT("\\"));
    lstrcat(bufferPtr, libName);
}


// apply use custom operation
void ExecuteUserCustomCodes() {
#pragma message(MESSAGE_RAISE_LOCATION "If you want to append custom code that is executed when the Dll is loaded, please add it here.") // NOLINT(clang-diagnostic-#pragma-messages)
}

// change this value, you can test process limitation
#define ENABLE_PROCESS_LIMITATION_TEST 0

bool ShouldExecuteAttachCode() {
#pragma message(MESSAGE_RAISE_LOCATION "If you return 0 here, none of the Attach related code in DllMain will be executed.") // NOLINT(clang-diagnostic-#pragma-messages)
    // this is example code, it will limit execute process name:
#if ENABLE_PROCESS_LIMITATION_TEST
    TCHAR szName[MAX_PATH];
    GetModuleFileName(NULL, szName, MAX_PATH);
    TCHAR* fileName = _tcsrchr(szName, _T('\\'));
    return fileName != nullptr && _tcscmp(fileName + 1, _T("xxxxx.exe")) == 0;
#else
    return true;
#endif
}
