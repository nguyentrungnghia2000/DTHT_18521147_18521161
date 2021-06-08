namespace DTHT
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewFile = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenFile = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbDataInput = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuildSolution = new System.Windows.Forms.Button();
            this.txbExeFileName = new System.Windows.Forms.TextBox();
            this.txbClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDataOutput = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.generatingToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(932, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // generatingToolStripMenuItem
            // 
            this.generatingToolStripMenuItem.Name = "generatingToolStripMenuItem";
            this.generatingToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.generatingToolStripMenuItem.Text = "Generating";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewFile,
            this.tsbOpenFile,
            this.tsbSaveFile,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(932, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewFile
            // 
            this.tsbNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewFile.Image")));
            this.tsbNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewFile.Name = "tsbNewFile";
            this.tsbNewFile.Size = new System.Drawing.Size(23, 22);
            this.tsbNewFile.Text = "toolStripButton1";
            this.tsbNewFile.ToolTipText = "New file";
            // 
            // tsbOpenFile
            // 
            this.tsbOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenFile.Image")));
            this.tsbOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenFile.Name = "tsbOpenFile";
            this.tsbOpenFile.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenFile.Text = "toolStripButton2";
            this.tsbOpenFile.ToolTipText = "Open file";
            this.tsbOpenFile.Click += new System.EventHandler(this.tsbOpenFile_Click);
            // 
            // tsbSaveFile
            // 
            this.tsbSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveFile.Image")));
            this.tsbSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveFile.Name = "tsbSaveFile";
            this.tsbSaveFile.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveFile.Text = "toolStripButton3";
            this.tsbSaveFile.ToolTipText = "Save";
            this.tsbSaveFile.Click += new System.EventHandler(this.tsbSaveFile_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(22, 22);
            this.toolStripLabel1.Text = "C#";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(21, 22);
            this.toolStripLabel2.Text = "VB";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbDataOutput);
            this.panel1.Controls.Add(this.txbDataInput);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 492);
            this.panel1.TabIndex = 2;
            // 
            // txbDataInput
            // 
            this.txbDataInput.Location = new System.Drawing.Point(3, 161);
            this.txbDataInput.Multiline = true;
            this.txbDataInput.Name = "txbDataInput";
            this.txbDataInput.Size = new System.Drawing.Size(398, 328);
            this.txbDataInput.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBuildSolution);
            this.panel2.Controls.Add(this.txbExeFileName);
            this.panel2.Controls.Add(this.txbClassName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 152);
            this.panel2.TabIndex = 0;
            // 
            // btnBuildSolution
            // 
            this.btnBuildSolution.Location = new System.Drawing.Point(122, 110);
            this.btnBuildSolution.Name = "btnBuildSolution";
            this.btnBuildSolution.Size = new System.Drawing.Size(137, 26);
            this.btnBuildSolution.TabIndex = 4;
            this.btnBuildSolution.Text = "Build Solution";
            this.btnBuildSolution.UseVisualStyleBackColor = true;
            this.btnBuildSolution.Click += new System.EventHandler(this.btnBuildSolution_Click);
            // 
            // txbExeFileName
            // 
            this.txbExeFileName.Location = new System.Drawing.Point(159, 60);
            this.txbExeFileName.Name = "txbExeFileName";
            this.txbExeFileName.Size = new System.Drawing.Size(198, 20);
            this.txbExeFileName.TabIndex = 3;
            // 
            // txbClassName
            // 
            this.txbClassName.Location = new System.Drawing.Point(159, 18);
            this.txbClassName.Name = "txbClassName";
            this.txbClassName.Size = new System.Drawing.Size(198, 20);
            this.txbClassName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(30, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exe File Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbDataOutput
            // 
            this.txbDataOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.txbDataOutput.Location = new System.Drawing.Point(407, 0);
            this.txbDataOutput.Name = "txbDataOutput";
            this.txbDataOutput.Size = new System.Drawing.Size(525, 492);
            this.txbDataOutput.TabIndex = 2;
            this.txbDataOutput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 541);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Formular Specification";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewFile;
        private System.Windows.Forms.ToolStripButton tsbOpenFile;
        private System.Windows.Forms.ToolStripButton tsbSaveFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbDataInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBuildSolution;
        private System.Windows.Forms.TextBox txbExeFileName;
        private System.Windows.Forms.TextBox txbClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txbDataOutput;
    }
}

