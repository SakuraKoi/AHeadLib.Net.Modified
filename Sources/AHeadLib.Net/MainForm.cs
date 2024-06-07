using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BlueMystic;
using Microsoft.CodeAnalysis.CSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AHeadLib.Net {
    public partial class MainForm : Form {
        private List<string> exportNames;

        public MainForm() {
            InitializeComponent();
            _ = new DarkModeCS(this);

#if DEBUG
            // for test only...
            editOutputDirectory.Text = "E:\\test";
            analyzeFile("C:\\Windows\\System32\\winmm.dll");
#endif
            var filePath = Assembly.GetExecutingAssembly().Location;
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            Text = $"AHeadLib.Net Modified v{fileVersionInfo.FileVersion}";
        }

        private void btnInputFilePick_Click(object sender, EventArgs e) {
            if (dialogInputFile.ShowDialog() != DialogResult.OK) {
                return;
            }

            analyzeFile(dialogInputFile.FileName);
        }

        private void analyzeFile(string fileName) {
            textLog.Text = "";
            Log("");
            textLog.AppendText($" AHeadLib.Net Modified | SakuraKooi {Environment.NewLine}", Color.Aqua);
            Log("");
            editInputFile.Text = fileName;
            editProjectName.Text = Path.GetFileNameWithoutExtension(editInputFile.Text);

            LogInfo($"Analyzing target file {Path.GetFileName(editInputFile.Text)} ...");
            string arch;
            PEFile.analyzeFile(editInputFile.Text, out exportNames, out arch);
            if (exportNames.Count == 0) {
                LogError("Error: Failed parse export table");
                return;
            }
            
            var names = exportNames;
            names.RemoveAll(x => {
                if (!SyntaxFacts.IsValidIdentifier(x) || x.Contains("@")) {
                    LogWarn($"Skipped symbol: {x}");
                    return true;
                }
                return false;
            });

            exportNames = names;
            LogSuccess($"Export table has {exportNames.Count} entries: ");
            foreach (var name in exportNames) {
                Log($"      - {name}");
            }
            LogSuccess($"Target DLL's Architecture: {arch}");
            Log("");
            LogInfo("Ready to generate");
        }

        private void btnOutputDirectoryPick_Click(object sender, EventArgs e) {
            using var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                editOutputDirectory.Text = fbd.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            Log("");
            if (!File.Exists(editInputFile.Text)) {
                LogError("Error: Input file not exists");
                return;
            }

            if (!Directory.Exists(editOutputDirectory.Text)) {
                LogError("Error: Output directory not exists");
                return;
            }

            if (editProjectName.Text.Trim().Length == 0) {
                LogError("Error: Project name is empty");
                return;
            }

            if (exportNames == null) {
                LogError("Error: Failed parse export table");
                return;
            }

            LogInfo($"Writing project to {editOutputDirectory.Text}");
            VSProjectGenerator generator = new VSProjectGenerator(editOutputDirectory.Text,
                Path.GetFileName(editInputFile.Text),
                editProjectName.Text,
                exportNames);

            generator.Write();

            LogSuccess("Project written.");
        }

        private void Log(string message) {
            textLog.AppendText(message + Environment.NewLine);
        }
        private void LogInfo(string message) {
            textLog.AppendText($" [*] {message}{Environment.NewLine}", Color.WhiteSmoke);
        }
        private void LogWarn(string message) {
            textLog.AppendText($" [*] {message}{Environment.NewLine}", Color.Yellow);
        }
        private void LogError(string message) {
            textLog.AppendText($" [-] {message}{Environment.NewLine}", Color.Red);
        }
        private void LogSuccess(string message) {
            textLog.AppendText($" [+] {message}{Environment.NewLine}", Color.GreenYellow);
        }

    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.ScrollToCaret();
        }
    }
}