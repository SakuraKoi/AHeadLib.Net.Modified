using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp;

namespace AHeadLib.Net {
    public partial class MainForm : Form {
        private List<string> exportNames;

        public MainForm() {
            InitializeComponent();

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
            editInputFile.Text = fileName;
            editProjectName.Text = Path.GetFileNameWithoutExtension(editInputFile.Text);

            Log($" [*] Analyzing target file {Path.GetFileName(editInputFile.Text)} ...");
            string arch;
            PEFile.analyzeFile(editInputFile.Text, out exportNames, out arch);
            Log($" [+] Export table has {exportNames.Count} entries: ");
            foreach (var name in exportNames) {
                Log($"      - {name}");
            }
            Log($" [+] Architecture: {arch}");
            Log("");
            Log(" [*] Ready to generate");
        }

        private void btnOutputDirectoryPick_Click(object sender, EventArgs e) {
            using var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                editOutputDirectory.Text = fbd.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            if (!File.Exists(editInputFile.Text)) {
                MessageBox.Show("Input file is not exists.");
                return;
            }

            if (!Directory.Exists(editOutputDirectory.Text)) {
                MessageBox.Show("Output Directory is not exists.");
                return;
            }

            if (exportNames == null) {
                MessageBox.Show("Failed get export table.");
                return;
            }

            var names = exportNames;
            names.RemoveAll(x => {
                if (!SyntaxFacts.IsValidIdentifier(x) || x.Contains("@")) {
                    Log($"Skip symbol:{x}");

                    return true;
                }

                return false;
            });

            exportNames = names;

            VSProjectGenerator generator = new VSProjectGenerator(editOutputDirectory.Text,
                Path.GetFileName(editInputFile.Text),
                editProjectName.Text,
                exportNames);

            generator.Write();

            Log("Write Finished.");
        }

        private void Log(string message) {
            textLog.AppendText(message + Environment.NewLine);
        }
    }
}