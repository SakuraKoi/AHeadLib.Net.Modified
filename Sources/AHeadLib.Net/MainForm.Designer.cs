namespace AHeadLib.Net
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.editInputFile = new System.Windows.Forms.TextBox();
            this.btnInputFilePick = new System.Windows.Forms.Button();
            this.btnOutputDirectoryPick = new System.Windows.Forms.Button();
            this.editOutputDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textLog = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dialogInputFile = new System.Windows.Forms.OpenFileDialog();
            this.editProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editInputFile
            // 
            this.editInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editInputFile.Location = new System.Drawing.Point(128, 16);
            this.editInputFile.Name = "editInputFile";
            this.editInputFile.Size = new System.Drawing.Size(392, 21);
            this.editInputFile.TabIndex = 1;
            // 
            // btnInputFilePick
            // 
            this.btnInputFilePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInputFilePick.Location = new System.Drawing.Point(519, 15);
            this.btnInputFilePick.Name = "btnInputFilePick";
            this.btnInputFilePick.Size = new System.Drawing.Size(42, 23);
            this.btnInputFilePick.TabIndex = 2;
            this.btnInputFilePick.Text = "...";
            this.btnInputFilePick.UseVisualStyleBackColor = true;
            this.btnInputFilePick.Click += new System.EventHandler(this.btnInputFilePick_Click);
            // 
            // btnOutputDirectoryPick
            // 
            this.btnOutputDirectoryPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputDirectoryPick.Location = new System.Drawing.Point(519, 39);
            this.btnOutputDirectoryPick.Name = "btnOutputDirectoryPick";
            this.btnOutputDirectoryPick.Size = new System.Drawing.Size(42, 23);
            this.btnOutputDirectoryPick.TabIndex = 5;
            this.btnOutputDirectoryPick.Text = "...";
            this.btnOutputDirectoryPick.UseVisualStyleBackColor = true;
            this.btnOutputDirectoryPick.Click += new System.EventHandler(this.btnOutputDirectoryPick_Click);
            // 
            // editOutputDirectory
            // 
            this.editOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editOutputDirectory.Location = new System.Drawing.Point(128, 40);
            this.editOutputDirectory.Name = "editOutputDirectory";
            this.editOutputDirectory.Size = new System.Drawing.Size(392, 21);
            this.editOutputDirectory.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output directory";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textLog
            // 
            this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLog.Location = new System.Drawing.Point(16, 96);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.Size = new System.Drawing.Size(544, 129);
            this.textLog.TabIndex = 6;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(464, 233);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(96, 24);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dialogInputFile
            // 
            this.dialogInputFile.Filter = "DLL|*.dll";
            // 
            // editProjectName
            // 
            this.editProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editProjectName.Location = new System.Drawing.Point(128, 64);
            this.editProjectName.Name = "editProjectName";
            this.editProjectName.Size = new System.Drawing.Size(432, 21);
            this.editProjectName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Project Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 274);
            this.Controls.Add(this.btnOutputDirectoryPick);
            this.Controls.Add(this.btnInputFilePick);
            this.Controls.Add(this.editOutputDirectory);
            this.Controls.Add(this.editInputFile);
            this.Controls.Add(this.editProjectName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AHeadLib.Net";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editInputFile;
        private System.Windows.Forms.Button btnInputFilePick;
        private System.Windows.Forms.Button btnOutputDirectoryPick;
        private System.Windows.Forms.TextBox editOutputDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.OpenFileDialog dialogInputFile;
        private System.Windows.Forms.TextBox editProjectName;
        private System.Windows.Forms.Label label3;
    }
}