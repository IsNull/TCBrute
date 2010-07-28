using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace truecryptbrute
{
    public partial class frmMain : Form
    {
        private bool bDontUpdate = false;
        public frmMain()
        {
            frmAbout abtoox = new frmAbout();
            abtoox.ShowDialog();
            InitializeComponent();

            #region Control Change Events

            this.txtTargetVolume.TextChanged +=new EventHandler(txtTargetVolume_TextChanged);
            this.txtWordListPath.TextChanged += new EventHandler(txtWordListPath_TextChanged);
            this.txtWordListOffset.TextChanged += new EventHandler(txtWordListOffset_TextChanged);
            this.chkIsSystemVol.CheckedChanged += new EventHandler(chkIsSystemVol_CheckedChanged);
            this.chkKeyfiles.CheckedChanged += new EventHandler(chkKeyfiles_CheckedChanged);
            this.cboThreads.TextChanged += new EventHandler(cboThreads_TextChanged);

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

        private void txtTargetVolume_TextChanged(object sender, EventArgs e) {
            UpdateConfig();
        }
        private void txtTrueCryptBinaryPath_TextChanged(object sender, EventArgs e) {
            UpdateConfig();
        }
        private void txtWordListPath_TextChanged(object sender, EventArgs e) {
            UpdateConfig();
        }
        private void txtWordListOffset_TextChanged(object sender, EventArgs e) {
            UpdateConfig();
        }
        private void chkIsSystemVol_CheckedChanged(object sender, EventArgs e) {
            UpdateConfig();
        }
        private void chkKeyfiles_CheckedChanged(object sender, EventArgs e) {
            UpdateConfig();
            if(this.chkKeyfiles.Checked) {
                this.btnOpenKeyFileDialoge.Enabled = true;
            } else {
                this.btnOpenKeyFileDialoge.Enabled = false;
            }
        }
        private void cboThreads_TextChanged(object sender, EventArgs e) {
            UpdateConfig();
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
            if(!bDontUpdate) {
                var crkconfg = ConfigController.Configuration;
                crkconfg.ContainerPath = this.txtTargetVolume.Text;
                crkconfg.MountAsSystemVolume = this.chkIsSystemVol.Checked;
                crkconfg.UseKeyFiles = this.chkKeyfiles.Checked;
                crkconfg.WordListPath = this.txtWordListPath.Text;
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
                bDontUpdate = true;
                this.txtTargetVolume.Text = value.ContainerPath;
                this.chkIsSystemVol.Checked = value.MountAsSystemVolume;
                this.txtWordListPath.Text = value.WordListPath;
                this.txtWordListOffset.Text = value.WordListOffset.ToString();
                this.cboThreads.Text = value.ThreadCount.ToString();
                bDontUpdate = false;
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




    }
}
