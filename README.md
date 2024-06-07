# AHeadLib.Net Modified

### What changed in this fork?

- DevExpress dependency removed 
- Builtin patcher feature removed
- More stylished ui (? 



## Info

The C# version of AHeadLib solves various problems such as instability, incompatibility with x64, and stuck file selection of the C++ version provided by many previous enthusiasts.    
This version supports both x86 and x64. The generated C++ project also supports camouflage of x86 and x64 DLLs. Just select the corresponding compilation configuration.  

# Overview
This project is based on .NET Framework 4.7.2. If you want to use it, you can directly download the compressed package below [Release](https://github.com/bodong1987/AHeadLib.Net/releases). 

**Note that this tool only supports exporting pure C interfaces. Some complex symbols such as C++ symbols are not supported for export. So there is a possibility that the new dll lacks necessary symbols. If your dll is a dll with only pure C API, such as winmm.dll, you can use it freely without any problem.**  

# How to Use
Open the tool and select the dll you want to disguise in the first line.
The second line selects a directory. Then click Generate, it will generate a complete Visual Studio 2022 C++ project for you. If nothing unexpected happens, open the corresponding sln and you can compile it.  
If you want to obtain other versions of the project, you can refer to the corresponding configuration and create a new project, or you can directly modify the vcxproj file to achieve your goal.   

# Change the code
Open the `UserImplementations.cpp` file. There are two user-defined methods. You can customize the original dll file path and append your own custom code in these two methods.  



Credits: [Code injection icons created by Freepik](https://www.flaticon.com/free-icons/code-injection)
