﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace truecryptbrute.View
{
    public partial class FrmMain : Form
    {
        private bool _bDontUpdate = false;
        public FrmMain()
        {
            var aboutBox = new FrmAbout();
            aboutBox.ShowDialog();
            InitializeComponent();

            this.Text = aboutBox.AssemblyTitle;
            MainTitle.Text = aboutBox.AssemblyTitle;

            

            #region Control Change Events

            this.txtTargetVolume.TextChanged += new EventHandler(Config_Changed);
            this.txtWordListPath.TextChanged += new EventHandler(Config_Changed);
            this.txtWordListOffset.TextChanged += new EventHandler(Config_Changed);
            this.chkIsSystemVol.CheckedChanged += new EventHandler(Config_Changed);
            this.chkHiddenVolume.CheckedChanged += new EventHandler(Config_Changed);
            this.chkKeyfiles.CheckedChanged += new EventHandler(chkKeyfiles_CheckedChanged);
            this.cboThreads.TextChanged += new EventHandler(Config_Changed);
            this.showPasswordCheckBox.CheckedChanged += new EventHandler(Config_Changed);

            #endregion

            #region Validate UserInput

            this.cboThreads.Validating +=new CancelEventHandler(cboThreads_Validating);
            this.txtWordListOffset.Validating +=new CancelEventHandler(txtWordListOffset_Validating);

            #endregion

            FindAndSetThreadCnt();
        }


        #region Validating

        private void cboThreads_Validating(object sender, CancelEventArgs e) {
            int res;
            bool state = true;
            if(Int32.TryParse((sender as ComboBox).Text, out res)) {
                if(res > 0) {
                    state = false;
                }
            }
            e.Cancel = state;
        }

        private void txtWordListOffset_Validating(object sender, CancelEventArgs e) {
            int res;
            bool state = true;
            if(Int32.TryParse((sender as TextBox).Text, out res)) {
                if(res >= 0) {
                    state = false;
                }
            }
            e.Cancel = state;
        }
        

        #endregion

        #region Events


        private void Config_Changed(object sender, EventArgs e) {
            UpdateConfig();
        }

        private void chkKeyfiles_CheckedChanged(object sender, EventArgs e) {
            Config_Changed(sender, e);

            if(this.chkKeyfiles.Checked) {
                this.btnOpenKeyFileDialoge.Enabled = true;
            } else {
                this.btnOpenKeyFileDialoge.Enabled = false;
            }
        }
        
        

        #endregion

        #region Configruation

        private void btnSaveConfic_Click(object sender, EventArgs e) {
            SaveFileDialog SaveConfigDlg = new SaveFileDialog();
            if(SaveConfigDlg.ShowDialog() == DialogResult.OK) {
                ConfigController.SaveCrackConfiguration(SaveConfigDlg.FileName);
            }
        }
        private void btnLoadJobConfic_Click(object sender, EventArgs e) {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if(OpenDlg.ShowDialog() == DialogResult.OK) {
                if(!ConfigController.LoadCrackConfiguration(OpenDlg.FileName)) {
                    MessageBox.Show("Failed to load settings - is this a vaild configuration file?");
                }
            }
            this.Settings = ConfigController.Configuration;
        }

        private void UpdateConfig() {
            int threads; 
            if(!_bDontUpdate) {
                var crkconfg = ConfigController.Configuration;
                crkconfg.ContainerPath = this.txtTargetVolume.Text;
                crkconfg.MountAsSystemVolume = this.chkIsSystemVol.Checked;
                crkconfg.AttackHiddenVolume = this.chkHiddenVolume.Checked;
                crkconfg.UseKeyFiles = this.chkKeyfiles.Checked;
                crkconfg.WordListPath = this.txtWordListPath.Text;
                crkconfg.ShowPassword = this.showPasswordCheckBox.Checked;
                int offset;
                if(Int32.TryParse(this.txtWordListOffset.Text, out offset)) {
                    crkconfg.WordListOffset = offset;
                } else {
                    crkconfg.WordListOffset = 0;
                }
                if(Int32.TryParse(this.cboThreads.Text, out threads)) {
                    crkconfg.ThreadCount = threads;
                } else {
                    crkconfg.ThreadCount = 1;
                }
            }
        }
        
        public CrackConfiguration CrackConfig {
            get { return ConfigController.Configuration; }
        }

        private CrackConfiguration Settings {
            set {
                _bDontUpdate = true;
                this.txtTargetVolume.Text = value.ContainerPath;
                this.chkIsSystemVol.Checked = value.MountAsSystemVolume;
                this.chkHiddenVolume.Checked = value.AttackHiddenVolume;
                this.chkKeyfiles.Checked = value.UseKeyFiles;
                this.txtWordListPath.Text = value.WordListPath;
                this.txtWordListOffset.Text = value.WordListOffset.ToString();
                this.cboThreads.Text = value.ThreadCount.ToString();
                this.showPasswordCheckBox.Checked = value.ShowPassword;
                _bDontUpdate = false;
            }

        }
        #endregion

        #region File Browsers

        private void btnBrowseContainer_Click(object sender, EventArgs e) {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if(OpenDlg.ShowDialog() == DialogResult.OK) {
                this.txtTargetVolume.Text = OpenDlg.FileName;
            }
        }

        private void BrowseWordlist_Click(object sender, EventArgs e) {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if(OpenDlg.ShowDialog() == DialogResult.OK) {
                this.txtWordListPath.Text = OpenDlg.FileName;
            }
        }

        #endregion

        private void FindAndSetThreadCnt() {
            this.cboThreads.Text = Environment.ProcessorCount.ToString();
        }

        private void btnOpenKeyFileDialoge_Click(object sender, EventArgs e) {
            var dlgKeyFile = new View.frmKeyfiles(ConfigController.Configuration.KeyFiles);
            dlgKeyFile.ShowDialog();
            ConfigController.Configuration.KeyFiles = dlgKeyFile.KeyFiles;
        }

        private void progressPollingTimer_Tick(object sender, EventArgs e)
        {
            var wordList = WordList.WordListPasswordProvider.Instance;
            var progress = wordList.Progress;

            this.progressBar1.Value = progress;
            this.txtCurrentPass.Text = (showPasswordCheckBox.Checked ? wordList.LastPassword : null);
            this.lblProgress.Text = wordList.CurrentPasswordIndex + "/" + wordList.PasswordCount + " [" + progress + "%]";
        }

        /// <summary>
        /// Start polling WordListPasswordProvider for progress information.
        /// </summary>
        public void StartProgressTimer()
        {
            this.progressPollingTimer.Start();
        }

        /// <summary>
        /// Stop polling WordListPasswordProvider for progress information.
        /// </summary>
        public void StopProgressTimer()
        {
            this.progressPollingTimer.Stop();
        }
    }
}
