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
            InitializeComponent();

            #region Control Change Events

            this.txtTargetVolume.TextChanged +=new EventHandler(txtTargetVolume_TextChanged);
            this.txtTrueCryptBinaryPath.TextChanged +=new EventHandler(txtTrueCryptBinaryPath_TextChanged);
            this.txtWordListPath.TextChanged += new EventHandler(txtWordListPath_TextChanged);
            this.txtWordListOffset.TextChanged += new EventHandler(txtWordListOffset_TextChanged);
            this.chkIsSystemVol.CheckedChanged += new EventHandler(chkIsSystemVol_CheckedChanged);
            this.chkKeyfiles.CheckedChanged += new EventHandler(chkKeyfiles_CheckedChanged);

            #endregion

            #region Validate UserInput
            this.cboThreads.Validating +=new CancelEventHandler(cboThreads_Validating);

            #endregion

            FindAndSetTCPath();
            FindAndSetThreadCnt();
        }


        #region Validating

        private void cboThreads_Validating(object sender, CancelEventArgs e) {
            int res;
            e.Cancel = !Int32.TryParse((sender as ComboBox).Text, out res);
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
        

        #endregion

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
            if(!bDontUpdate) {
                var crkconfg = ConfigController.Configuration;
                crkconfg.TrueCryptBinaryPath = this.txtTrueCryptBinaryPath.Text;
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
            }
        }

        private CrackConfiguration Settings {
            set {
                bDontUpdate = true;
                this.txtTrueCryptBinaryPath.Text = value.TrueCryptBinaryPath;
                this.txtTargetVolume.Text = value.ContainerPath;
                this.chkIsSystemVol.Checked = value.MountAsSystemVolume;
                this.txtWordListPath.Text = value.WordListPath;
                this.txtWordListOffset.Text = value.WordListOffset.ToString();
                bDontUpdate = false;
            }

        }

        #region File Browsers

        private void btnBrowseTrueCrypt_Click(object sender, EventArgs e) {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if(OpenDlg.ShowDialog() == DialogResult.OK) {
                this.txtTrueCryptBinaryPath.Text = OpenDlg.FileName;
            }
        }

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

        private void FindAndSetTCPath() {
            this.txtTrueCryptBinaryPath.Text = truecrypt.TrueCryptInstallation.FindTrueCryptInstallation();
        }
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
