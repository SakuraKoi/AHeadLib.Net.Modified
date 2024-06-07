// @generated
// AHeadLib.Net
// https://github.com/SakuraKoi/AHeadLib.Net
// Powered by bodong | Modified by.SakuraKooi

#include <Windows.h>
#include <cassert>
#include <tchar.h>

#define STRINGIFY(x) #x
#define TOSTRING(x) STRINGIFY(x)

#define MESSAGE_RAISE_LOCATION __FILE__ "(" TOSTRING(__LINE__) "): "

extern "C"
{
    // fill original library path here
    // use absolute file path
    void GetOrignalLibraryPath(TCHAR* bufferPtr, int bufferLength, const TCHAR* libName)
    {
        assert(bufferPtr != nullptr);
        assert(libName != nullptr);

        // By default, the path of the original Library is considered to be the system directory. 
        // If you need another path, be sure to modify the code here and replace it with the correct location.
        #pragma message(MESSAGE_RAISE_LOCATION "If you need to adjust the absolute path of the original library file, please modify this.")

        GetSystemDirectory(bufferPtr, bufferLength);
        lstrcat(bufferPtr, TEXT("\\"));
        lstrcat(bufferPtr, libName);
    }


    // apply use custom operation
    void __ExecuteUserCutomCodes()
    {
        #pragma message(MESSAGE_RAISE_LOCATION "If you want to append custom code that is executed when the Dll is loaded, please add it here.")
    }

    int __CheckShouldExecuteAttachCode()
    {
        // this is example code, it limit execute process name:
        #if 0
        TCHAR szName[MAX_PATH];
        GetModuleFileName(NULL, szName, MAX_PATH);
        TCHAR* fileName = _tcsrchr(szName, _T('\\'));
        if (fileName != nullptr && _tcscmp(fileName + 1, _T("xxxxx.exe")) == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
        #endif

        #pragma message(MESSAGE_RAISE_LOCATION "If you return 0 here, none of the Attach related code in DllMain will be executed.")

        return 1;
    }
}