namespace truecryptbrute
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnDoCrack = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpenKeyFileDialoge = new System.Windows.Forms.Button();
            this.chkKeyfiles = new System.Windows.Forms.CheckBox();
            this.btnLoadJobConfic = new System.Windows.Forms.Button();
            this.btnSaveConfic = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetVolume = new System.Windows.Forms.TextBox();
            this.btnChoosePartition = new System.Windows.Forms.Button();
            this.btnBrowseContainer = new System.Windows.Forms.Button();
            this.chkIsSystemVol = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWordListOffset = new System.Windows.Forms.TextBox();
            this.txtWordListPath = new System.Windows.Forms.TextBox();
            this.BrowseWordlist = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseTrueCrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrueCryptBinaryPath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 164);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 313);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.btnPause);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.txtLog);
            this.tabPage1.Controls.Add(this.btnDoCrack);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(757, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(695, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(24, 95);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(695, 161);
            this.txtLog.TabIndex = 1;
            // 
            // btnDoCrack
            // 
            this.btnDoCrack.Location = new System.Drawing.Point(24, 49);
            this.btnDoCrack.Name = "btnDoCrack";
            this.btnDoCrack.Size = new System.Drawing.Size(91, 23);
            this.btnDoCrack.TabIndex = 0;
            this.btnDoCrack.Text = "Crack it!";
            this.btnDoCrack.UseVisualStyleBackColor = true;
            this.btnDoCrack.Click += new System.EventHandler(this.btnDoCrack_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.btnLoadJobConfic);
            this.tabPage2.Controls.Add(this.btnSaveConfic);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnBrowseTrueCrypt);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtTrueCryptBinaryPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(757, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Job Config";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOpenKeyFileDialoge);
            this.groupBox3.Controls.Add(this.chkKeyfiles);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(597, 59);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(154, 83);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Keyfiles";
            // 
            // btnOpenKeyFileDialoge
            // 
            this.btnOpenKeyFileDialoge.Enabled = false;
            this.btnOpenKeyFileDialoge.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnOpenKeyFileDialoge.Location = new System.Drawing.Point(21, 43);
            this.btnOpenKeyFileDialoge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenKeyFileDialoge.Name = "btnOpenKeyFileDialoge";
            this.btnOpenKeyFileDialoge.Size = new System.Drawing.Size(120, 22);
            this.btnOpenKeyFileDialoge.TabIndex = 1;
            this.btnOpenKeyFileDialoge.Text = "Config Keyfiles";
            this.btnOpenKeyFileDialoge.UseVisualStyleBackColor = true;
            // 
            // chkKeyfiles
            // 
            this.chkKeyfiles.AutoSize = true;
            this.chkKeyfiles.Location = new System.Drawing.Point(21, 19);
            this.chkKeyfiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkKeyfiles.Name = "chkKeyfiles";
            this.chkKeyfiles.Size = new System.Drawing.Size(84, 17);
            this.chkKeyfiles.TabIndex = 0;
            this.chkKeyfiles.Text = "Use Keyfiles";
            this.chkKeyfiles.UseVisualStyleBackColor = true;
            // 
            // btnLoadJobConfic
            // 
            this.btnLoadJobConfic.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnLoadJobConfic.Location = new System.Drawing.Point(617, 181);
            this.btnLoadJobConfic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadJobConfic.Name = "btnLoadJobConfic";
            this.btnLoadJobConfic.Size = new System.Drawing.Size(121, 22);
            this.btnLoadJobConfic.TabIndex = 14;
            this.btnLoadJobConfic.Text = "Load Job Confic";
            this.btnLoadJobConfic.UseVisualStyleBackColor = true;
            this.btnLoadJobConfic.Click += new System.EventHandler(this.btnLoadJobConfic_Click);
            // 
            // btnSaveConfic
            // 
            this.btnSaveConfic.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnSaveConfic.Location = new System.Drawing.Point(618, 217);
            this.btnSaveConfic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveConfic.Name = "btnSaveConfic";
            this.btnSaveConfic.Size = new System.Drawing.Size(121, 22);
            this.btnSaveConfic.TabIndex = 13;
            this.btnSaveConfic.Text = "Save Job Confic";
            this.btnSaveConfic.UseVisualStyleBackColor = true;
            this.btnSaveConfic.Click += new System.EventHandler(this.btnSaveConfic_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTargetVolume);
            this.groupBox2.Controls.Add(this.btnChoosePartition);
            this.groupBox2.Controls.Add(this.btnBrowseContainer);
            this.groupBox2.Controls.Add(this.chkIsSystemVol);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(37, 59);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(545, 82);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Volume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target Volume";
            // 
            // txtTargetVolume
            // 
            this.txtTargetVolume.Location = new System.Drawing.Point(111, 30);
            this.txtTargetVolume.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTargetVolume.Name = "txtTargetVolume";
            this.txtTargetVolume.Size = new System.Drawing.Size(253, 20);
            this.txtTargetVolume.TabIndex = 4;
            // 
            // btnChoosePartition
            // 
            this.btnChoosePartition.Enabled = false;
            this.btnChoosePartition.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnChoosePartition.Location = new System.Drawing.Point(437, 27);
            this.btnChoosePartition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChoosePartition.Name = "btnChoosePartition";
            this.btnChoosePartition.Size = new System.Drawing.Size(103, 22);
            this.btnChoosePartition.TabIndex = 7;
            this.btnChoosePartition.Text = "Select Partition";
            this.btnChoosePartition.UseVisualStyleBackColor = true;
            // 
            // btnBrowseContainer
            // 
            this.btnBrowseContainer.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnBrowseContainer.Location = new System.Drawing.Point(383, 27);
            this.btnBrowseContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowseContainer.Name = "btnBrowseContainer";
            this.btnBrowseContainer.Size = new System.Drawing.Size(35, 22);
            this.btnBrowseContainer.TabIndex = 6;
            this.btnBrowseContainer.Text = "...";
            this.btnBrowseContainer.UseVisualStyleBackColor = true;
            this.btnBrowseContainer.Click += new System.EventHandler(this.btnBrowseContainer_Click);
            // 
            // chkIsSystemVol
            // 
            this.chkIsSystemVol.AutoSize = true;
            this.chkIsSystemVol.Location = new System.Drawing.Point(111, 58);
            this.chkIsSystemVol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkIsSystemVol.Name = "chkIsSystemVol";
            this.chkIsSystemVol.Size = new System.Drawing.Size(145, 17);
            this.chkIsSystemVol.TabIndex = 0;
            this.chkIsSystemVol.Text = "Mount as System Volume";
            this.chkIsSystemVol.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtWordListOffset);
            this.groupBox1.Controls.Add(this.txtWordListPath);
            this.groupBox1.Controls.Add(this.BrowseWordlist);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(37, 165);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(545, 87);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wordlist";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Offset";
            // 
            // txtWordListOffset
            // 
            this.txtWordListOffset.Location = new System.Drawing.Point(111, 45);
            this.txtWordListOffset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWordListOffset.Name = "txtWordListOffset";
            this.txtWordListOffset.Size = new System.Drawing.Size(109, 20);
            this.txtWordListOffset.TabIndex = 11;
            this.txtWordListOffset.Text = "0";
            // 
            // txtWordListPath
            // 
            this.txtWordListPath.Location = new System.Drawing.Point(111, 19);
            this.txtWordListPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWordListPath.Name = "txtWordListPath";
            this.txtWordListPath.Size = new System.Drawing.Size(253, 20);
            this.txtWordListPath.TabIndex = 8;
            // 
            // BrowseWordlist
            // 
            this.BrowseWordlist.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BrowseWordlist.ForeColor = System.Drawing.SystemColors.InfoText;
            this.BrowseWordlist.Location = new System.Drawing.Point(383, 17);
            this.BrowseWordlist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BrowseWordlist.Name = "BrowseWordlist";
            this.BrowseWordlist.Size = new System.Drawing.Size(35, 22);
            this.BrowseWordlist.TabIndex = 10;
            this.BrowseWordlist.Text = "...";
            this.BrowseWordlist.UseVisualStyleBackColor = true;
            this.BrowseWordlist.Click += new System.EventHandler(this.BrowseWordlist_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Wordlist";
            // 
            // btnBrowseTrueCrypt
            // 
            this.btnBrowseTrueCrypt.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnBrowseTrueCrypt.Location = new System.Drawing.Point(421, 15);
            this.btnBrowseTrueCrypt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowseTrueCrypt.Name = "btnBrowseTrueCrypt";
            this.btnBrowseTrueCrypt.Size = new System.Drawing.Size(35, 22);
            this.btnBrowseTrueCrypt.TabIndex = 3;
            this.btnBrowseTrueCrypt.Text = "...";
            this.btnBrowseTrueCrypt.UseVisualStyleBackColor = true;
            this.btnBrowseTrueCrypt.Click += new System.EventHandler(this.btnBrowseTrueCrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path TrueCrypt";
            // 
            // txtTrueCryptBinaryPath
            // 
            this.txtTrueCryptBinaryPath.Location = new System.Drawing.Point(149, 17);
            this.txtTrueCryptBinaryPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrueCryptBinaryPath.Name = "txtTrueCryptBinaryPath";
            this.txtTrueCryptBinaryPath.Size = new System.Drawing.Size(253, 20);
            this.txtTrueCryptBinaryPath.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::truecryptbrute.Properties.Resources.tc_brute_bkg;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 147);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(24, 49);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(91, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause.";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.BrowseWordlist;
            this.ClientSize = new System.Drawing.Size(793, 509);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "true.crypt.brute - by securityvision.ch";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkIsSystemVol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTargetVolume;
        private System.Windows.Forms.Button btnChoosePartition;
        private System.Windows.Forms.Button btnBrowseContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWordListPath;
        private System.Windows.Forms.Button BrowseWordlist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseTrueCrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrueCryptBinaryPath;
        private System.Windows.Forms.Button btnLoadJobConfic;
        private System.Windows.Forms.Button btnSaveConfic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWordListOffset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenKeyFileDialoge;
        private System.Windows.Forms.CheckBox chkKeyfiles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnDoCrack;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnPause;
    }
}

