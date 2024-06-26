﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AHeadLib.Net
{
    public class VSProjectGenerator(string directory, string dllName, string projectName, IEnumerable<string> methods) {
        public readonly string Directory = directory;
        public readonly string DllName = dllName;
        public readonly IEnumerable<string> Methods = methods;
        public readonly string SolutionID = Guid.NewGuid().ToString();
        public readonly string SolutionID2 = Guid.NewGuid().ToString();
        public readonly string ProjectID = Guid.NewGuid().ToString();
        public readonly string FilterId1 = Guid.NewGuid().ToString();
        public readonly string FilterId2 = Guid.NewGuid().ToString();
        public readonly string FilterId3 = Guid.NewGuid().ToString();
        public readonly string FilterId4 = Guid.NewGuid().ToString();

        public void Write()
        {
            WriteCpp();
            WriteCppTemplates();
            WriteAsm();
            WriteCPPProject();
        }

        #region C++ Libs
        private void WriteCppTemplates()
        {
            WriteComonUtilFile(Path.Combine(Directory, "UserFiles/UserImplementations.cpp"), Properties.Resources.UserImplementations);
        }
        #endregion

        #region C++        

        private void WriteCpp()
        {
            CodeWriter writer = new CodeWriter(Path.Combine(Directory, "GeneratedFiles", Path.GetFileNameWithoutExtension(DllName) + ".c"));

            string exportedPointers = string.Join(Environment.NewLine, Methods.Select(x => $"void* {x}Ptr = NULL;"));
            string exportedFunctions = string.Join(Environment.NewLine, Methods.Select(x => $"extern void WINAPI ASM_{x}();"));
            string exportedLinker = string.Join(Environment.NewLine, Methods.Select(x =>
            {
                return 
                $"#if __X64_BUILD__\n" +
                $"#pragma comment(linker, \"/EXPORT:{x}=ASM_{x}\")\n" +
                $"#else\n" +
                $"#pragma comment(linker, \"/EXPORT:{x}=_ASM_{x}@8\")\n" +
                $"#endif";
            }));
            string bindPointers = string.Join(Environment.NewLine + "    ", Methods.Select(x => $"{x}Ptr = __CheckedGetFunction(module, \"{x}\");"));

            string cppCode = Properties.Resources.CppHelper;
            cppCode = cppCode.Replace("// ${EXPORTED_POINTERS}", exportedPointers);
            cppCode = cppCode.Replace("// ${EXPORTED_FUNCTIONS}", exportedFunctions);
            cppCode = cppCode.Replace("${LIBRARY_NAME}", DllName);
            cppCode = cppCode.Replace("// ${BIND_POINTERS}", bindPointers);
            cppCode = cppCode.Replace("// ${EXPORTED_LINKERS}", exportedLinker);

            writer.Write(cppCode);
            writer.WriteNewLine();
            writer.Save();

            CodeWriter mainWriter = new CodeWriter(Path.Combine(Directory, "GeneratedFiles", Path.GetFileNameWithoutExtension(DllName) + "_DllMain.c"));

            mainWriter.Write(Properties.Resources.DllMain);
            mainWriter.Save();
        }
        #endregion

        #region Asm
        private void WriteAsm()
        {
            {
                CodeWriter x86Writer = new CodeWriter(Path.Combine(Directory, "GeneratedFiles", Path.GetFileNameWithoutExtension(DllName) + "_x86.asm"));

                StringBuilder builder = new StringBuilder();
                string externDefs = string.Join(Environment.NewLine + "    ", Methods.Select(x => $"EXTERNDEF _{x}Ptr:DWORD"));
                string funcs = string.Join(Environment.NewLine, Methods.Select(x =>
                {
                    builder.Clear();
                    builder.AppendLine($"_ASM_{x}@8 PROC");
                    builder.AppendLine($"    jmp DWORD PTR [_{x}Ptr]");
                    builder.AppendLine($"_ASM_{x}@8 ENDP");

                    return builder.ToString();
                }));

                string asmCode = Properties.Resources.Asm_x86;
                asmCode = asmCode.Replace("${EXTERNDEF_POINTERS}", externDefs);
                asmCode = asmCode.Replace("${FUNCTIONS}", funcs);

                x86Writer.Write(asmCode);
                x86Writer.Save();
            }

            {
                CodeWriter x64Writer = new CodeWriter(Path.Combine(Directory, "GeneratedFiles", Path.GetFileNameWithoutExtension(DllName) + "_x64.asm"));

                StringBuilder builder = new StringBuilder();
                string externDefs = string.Join(Environment.NewLine + "    ", Methods.Select(x => $"EXTERNDEF {x}Ptr:QWORD"));
                string funcs = string.Join(Environment.NewLine, Methods.Select(x =>
                {
                    builder.Clear();
                    builder.AppendLine($"ASM_{x} PROC");
                    builder.AppendLine($"    jmp [{x}Ptr]");
                    builder.AppendLine($"ASM_{x} ENDP");

                    return builder.ToString();
                }));

                string asmCode = Properties.Resources.Asm_x64;
                asmCode = asmCode.Replace("${EXTERNDEF_POINTERS}", externDefs);
                asmCode = asmCode.Replace("${FUNCTIONS}", funcs);

                x64Writer.Write(asmCode);
                x64Writer.Save();
            }
        }
        #endregion

        #region Common Files
        private void WriteBinaryCodeFile(string name, byte[] bytes)
        {
            CodeWriter wirter = new CodeWriter(name);

            string codes = Encoding.UTF8.GetString(bytes);
            codes = codes.Replace("${LIB_NAME}", Path.GetFileNameWithoutExtension(DllName));
            codes = codes.Replace("${PROJECT_NAME}", projectName);
            codes = codes.Replace("${SOLUTION_ID}", SolutionID);
            codes = codes.Replace("${SOLUTION_ID_2}", SolutionID2);
            codes = codes.Replace("${PROJECT_ID}", ProjectID);
            codes = codes.Replace("${FILTER_ID_1}", FilterId1);
            codes = codes.Replace("${FILTER_ID_2}", FilterId2);
            codes = codes.Replace("${FILTER_ID_3}", FilterId3);
            codes = codes.Replace("${FILTER_ID_4}", FilterId4);

            wirter.Write(codes);
            wirter.Save();
        }

        private void WriteComonUtilFile(string name, string text)
        {
            CodeWriter writer = new CodeWriter(name);

            writer.Write(text);
            writer.Save();
        }
        #endregion

        #region Projects
        private void WriteCPPProject()
        {
            WriteBinaryCodeFile(Path.Combine(Directory, projectName + ".vcxproj"), Properties.Resources.vcxprojTemplate);
            WriteBinaryCodeFile(Path.Combine(Directory, projectName + ".vcxproj.filters"), Properties.Resources.vcxprojTemplate_filters);
            WriteBinaryCodeFile(Path.Combine(Directory, projectName + ".sln"), Properties.Resources.solution);
        }
        #endregion
    }
}
