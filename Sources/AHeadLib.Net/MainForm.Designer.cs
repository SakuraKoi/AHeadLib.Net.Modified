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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dialogInputFile = new System.Windows.Forms.OpenFileDialog();
            this.editProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editInputFile
            // 
            this.editInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editInputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.editInputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editInputFile.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.editInputFile.Location = new System.Drawing.Point(120, 16);
            this.editInputFile.Margin = new System.Windows.Forms.Padding(4);
            this.editInputFile.Name = "editInputFile";
            this.editInputFile.Size = new System.Drawing.Size(472, 23);
            this.editInputFile.TabIndex = 1;
            // 
            // btnInputFilePick
            // 
            this.btnInputFilePick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInputFilePick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnInputFilePick.FlatAppearance.BorderSize = 0;
            this.btnInputFilePick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputFilePick.Location = new System.Drawing.Point(600, 16);
            this.btnInputFilePick.Margin = new System.Windows.Forms.Padding(4);
            this.btnInputFilePick.Name = "btnInputFilePick";
            this.btnInputFilePick.Size = new System.Drawing.Size(49, 23);
            this.btnInputFilePick.TabIndex = 2;
            this.btnInputFilePick.Text = "...";
            this.btnInputFilePick.UseVisualStyleBackColor = false;
            this.btnInputFilePick.Click += new System.EventHandler(this.btnInputFilePick_Click);
            // 
            // btnOutputDirectoryPick
            // 
            this.btnOutputDirectoryPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputDirectoryPick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnOutputDirectoryPick.FlatAppearance.BorderSize = 0;
            this.btnOutputDirectoryPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutputDirectoryPick.Location = new System.Drawing.Point(600, 48);
            this.btnOutputDirectoryPick.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutputDirectoryPick.Name = "btnOutputDirectoryPick";
            this.btnOutputDirectoryPick.Size = new System.Drawing.Size(49, 23);
            this.btnOutputDirectoryPick.TabIndex = 5;
            this.btnOutputDirectoryPick.Text = "...";
            this.btnOutputDirectoryPick.UseVisualStyleBackColor = false;
            this.btnOutputDirectoryPick.Click += new System.EventHandler(this.btnOutputDirectoryPick_Click);
            // 
            // editOutputDirectory
            // 
            this.editOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editOutputDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.editOutputDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editOutputDirectory.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.editOutputDirectory.Location = new System.Drawing.Point(120, 48);
            this.editOutputDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.editOutputDirectory.Name = "editOutputDirectory";
            this.editOutputDirectory.Size = new System.Drawing.Size(472, 23);
            this.editOutputDirectory.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output directory";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerate.Location = new System.Drawing.Point(520, 408);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(131, 40);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
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
            this.editProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.editProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editProjectName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.editProjectName.Location = new System.Drawing.Point(120, 80);
            this.editProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.editProjectName.Name = "editProjectName";
            this.editProjectName.Size = new System.Drawing.Size(472, 23);
            this.editProjectName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Project Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textLog
            // 
            this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textLog.Location = new System.Drawing.Point(16, 112);
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.Size = new System.Drawing.Size(632, 288);
            this.textLog.TabIndex = 10;
            this.textLog.Text = "";
            this.textLog.TextChanged += new System.EventHandler(this.textLog_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(665, 465);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.btnOutputDirectoryPick);
            this.Controls.Add(this.btnInputFilePick);
            this.Controls.Add(this.editOutputDirectory);
            this.Controls.Add(this.editInputFile);
            this.Controls.Add(this.editProjectName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.OpenFileDialog dialogInputFile;
        private System.Windows.Forms.TextBox editProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox textLog;
    }
}