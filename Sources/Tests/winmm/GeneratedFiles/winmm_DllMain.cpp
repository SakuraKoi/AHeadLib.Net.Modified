// @generated
// AHeadLib.Net
// https://github.com/SakuraKoi/AHeadLib.Net
// Powered by bodong | Modified by.SakuraKooi

#include <windows.h>

extern void CheckedLoad();
extern void ExecuteUserCutomCodes();
extern bool ShouldExecuteAttachCode();

BOOL WINAPI DllMain(
    HINSTANCE hinstDLL,  // handle to DLL module
    DWORD fdwReason,     // reason for calling function
    LPVOID lpvReserved)  // reserved
{
    // Perform actions based on the reason for calling.
    switch (fdwReason)
    {
    case DLL_PROCESS_ATTACH:
        // Initialize once for each new process.
        // Return FALSE to fail DLL load.
        CheckedLoad();

        if (ShouldExecuteAttachCode())
        {
            // apply user custom codes
            ExecuteUserCustomCodes();
        }

        break;
        
    case DLL_THREAD_ATTACH: // Do thread-specific initialization.
    case DLL_THREAD_DETACH: // Do thread-specific cleanup.        
        break;

    case DLL_PROCESS_DETACH:

        if (lpvReserved != nullptr)
        {
            break; // do not do cleanup if process termination scenario
        }

        // Perform any necessary cleanup.
        break;
    default:
        break;
    }
    return TRUE;  // Successful DLL_PROCESS_ATTACH.
}


