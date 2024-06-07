using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp;

namespace AHeadLib.Net {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

#if DEBUG
            // for test only...
            editInputFile.Text = "C:\\Windows\\System32\\winmm.dll";
            editOutputDirectory.Text = "E:\\Desktop\\New Folder";
#endif
            var filePath = Assembly.GetExecutingAssembly().Location;
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
            Text = $"AHeadLib.Net Modified v{fileVersionInfo.FileVersion}";
        }

        private void btnInputFilePick_Click(object sender, EventArgs e) {
            if (dialogInputFile.ShowDialog() != DialogResult.OK) {
                return;
            }

            editInputFile.Text = dialogInputFile.FileName;
            editProjectName.Text = Path.GetFileNameWithoutExtension(editInputFile.Text);
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

            var exportNames = DllExportInfo.ReadFromFile(editInputFile.Text);

            if (exportNames == null) {
                MessageBox.Show("Failed get export table.");
                return;
            }

            var names = exportNames.ToList();
            names.RemoveAll(x => {
                if (!SyntaxFacts.IsValidIdentifier(x) || x.Contains("@")) {
                    Log($"Skip symbol:{x}");

                    return true;
                }

                return false;
            });

            exportNames = names;

            VSProjectGenerator generator = new VSProjectGenerator(editOutputDirectory.Text, editProjectName.Text, exportNames);

            generator.Write();

            Log("Write Finished.");
        }

        private void Log(string message) {
            textLog.AppendText(message + Environment.NewLine);
        }
    }
}