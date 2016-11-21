namespace truecryptbrute.View
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.showPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrentPass = new System.Windows.Forms.TextBox();
            this.btnPause = new System.Windows.Forms.Button();
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
            this.chkHiddenVolume = new System.Windows.Forms.CheckBox();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboThreads = new System.Windows.Forms.ComboBox();
            this.MainTitle = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.progressPollingTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tabPage1.Controls.Add(this.showPasswordCheckBox);
            this.tabPage1.Controls.Add(this.lblProgress);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtCurrentPass);
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
            // showPasswordCheckBox
            // 
            this.showPasswordCheckBox.AutoSize = true;
            this.showPasswordCheckBox.Checked = true;
            this.showPasswordCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPasswordCheckBox.Location = new System.Drawing.Point(288, 90);
            this.showPasswordCheckBox.Name = "showPasswordCheckBox";
            this.showPasswordCheckBox.Size = new System.Drawing.Size(128, 21);
            this.showPasswordCheckBox.TabIndex = 7;
            this.showPasswordCheckBox.Text = "Show password";
            this.showPasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(434, 52);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(21, 13);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "0%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "current:";
            // 
            // txtCurrentPass
            // 
            this.txtCurrentPass.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtCurrentPass.Location = new System.Drawing.Point(216, 49);
            this.txtCurrentPass.Name = "txtCurrentPass";
            this.txtCurrentPass.ReadOnly = true;
            this.txtCurrentPass.Size = new System.Drawing.Size(194, 20);
            this.txtCurrentPass.TabIndex = 4;
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 20);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(695, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(24, 95);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(695, 161);
            this.txtLog.ReadOnly = true;
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
            this.groupBox3.Location = new System.Drawing.Point(575, 49);
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
            this.btnOpenKeyFileDialoge.Click += new System.EventHandler(this.btnOpenKeyFileDialoge_Click);
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
            this.btnLoadJobConfic.Location = new System.Drawing.Point(595, 171);
            this.btnLoadJobConfic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadJobConfic.Name = "btnLoadJobConfic";
            this.btnLoadJobConfic.Size = new System.Drawing.Size(121, 22);
            this.btnLoadJobConfic.TabIndex = 14;
            this.btnLoadJobConfic.Text = "Load Job Confic";
            this.btnLoadJobConfic.Text = "Load Job Config";
            this.btnLoadJobConfic.UseVisualStyleBackColor = true;
            this.btnLoadJobConfic.Click += new System.EventHandler(this.btnLoadJobConfic_Click);
            // 
            // btnSaveConfic
            // 
            this.btnSaveConfic.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnSaveConfic.Location = new System.Drawing.Point(596, 207);
            this.btnSaveConfic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveConfic.Name = "btnSaveConfic";
            this.btnSaveConfic.Size = new System.Drawing.Size(121, 22);
            this.btnSaveConfic.TabIndex = 13;
            this.btnSaveConfic.Text = "Save Job Confic";
            this.btnSaveConfic.Text = "Save Job Config";
            this.btnSaveConfic.UseVisualStyleBackColor = true;
            this.btnSaveConfic.Click += new System.EventHandler(this.btnSaveConfic_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkHiddenVolume);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTargetVolume);
            this.groupBox2.Controls.Add(this.btnChoosePartition);
            this.groupBox2.Controls.Add(this.btnBrowseContainer);
            this.groupBox2.Controls.Add(this.chkIsSystemVol);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(15, 49);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(545, 82);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Volume";
            // 
            // chkHiddenVolume
            // 
            this.chkHiddenVolume.AutoSize = true;
            this.chkHiddenVolume.Location = new System.Drawing.Point(264, 57);
            this.chkHiddenVolume.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkHiddenVolume.Name = "chkHiddenVolume";
            this.chkHiddenVolume.Size = new System.Drawing.Size(95, 17);
            this.chkHiddenVolume.TabIndex = 8;
            this.chkHiddenVolume.Text = "HiddenVolume";
            this.chkHiddenVolume.UseVisualStyleBackColor = true;
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
            this.chkIsSystemVol.Enabled = false;
            this.chkIsSystemVol.Location = new System.Drawing.Point(111, 58);
            this.chkIsSystemVol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkIsSystemVol.Name = "chkIsSystemVol";
            this.chkIsSystemVol.Size = new System.Drawing.Size(147, 17);
            this.chkIsSystemVol.TabIndex = 0;
            this.chkIsSystemVol.Text = "Is System Volume Header";
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
            this.groupBox1.Location = new System.Drawing.Point(15, 155);
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
            this.label4.Location = new System.Drawing.Point(7, 48);
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(757, 287);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Global Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cboThreads);
            this.groupBox4.Location = new System.Drawing.Point(20, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(487, 87);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Threading";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(461, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Note: This parameter was automatic set to fit your system. Change only if you kno" +
    "w what you do.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Thread count:";
            // 
            // cboThreads
            // 
            this.cboThreads.FormattingEnabled = true;
            this.cboThreads.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cboThreads.Location = new System.Drawing.Point(93, 19);
            this.cboThreads.Name = "cboThreads";
            this.cboThreads.Size = new System.Drawing.Size(35, 21);
            this.cboThreads.TabIndex = 0;
            this.cboThreads.Text = "1";
            // 
            // MainTitle
            // 
            this.MainTitle.AutoSize = true;
            this.MainTitle.BackColor = System.Drawing.Color.Transparent;
            this.MainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MainTitle.Location = new System.Drawing.Point(27, 40);
            this.MainTitle.Name = "MainTitle";
            this.MainTitle.Size = new System.Drawing.Size(108, 24);
            this.MainTitle.TabIndex = 2;
            this.MainTitle.Text = "[app Name]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(28, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "by IsNull - securityvision.ch 2012 ";
            // 
            // progressPollingTimer
            // 
            this.progressPollingTimer.Interval = 500;
            this.progressPollingTimer.Tick += new System.EventHandler(this.progressPollingTimer_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::truecryptbrute.Properties.Resources.tc_brute_bkg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.BrowseWordlist;
            this.ClientSize = new System.Drawing.Size(793, 509);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.MainTitle);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[app Name]";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnLoadJobConfic;
        private System.Windows.Forms.Button btnSaveConfic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWordListOffset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenKeyFileDialoge;
        private System.Windows.Forms.CheckBox chkKeyfiles;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnDoCrack;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrentPass;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboThreads;
        private System.Windows.Forms.Label MainTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkHiddenVolume;
        private System.Windows.Forms.Timer progressPollingTimer;
        private System.Windows.Forms.CheckBox showPasswordCheckBox;
    }
}

