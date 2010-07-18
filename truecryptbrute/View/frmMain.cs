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

            FindAndSetTCPath();
        }


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
                ConfigurationController.Instance.SaveCrackConfiguration(SaveConfigDlg.FileName);
            }
        }
        private void btnLoadJobConfic_Click(object sender, EventArgs e) {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if(OpenDlg.ShowDialog() == DialogResult.OK) {
                if(!ConfigurationController.Instance.LoadCrackConfiguration(OpenDlg.FileName)) {
                    MessageBox.Show("Failed to load settings - is this a vaild configuration file?");
                }
            }
            this.Settings = ConfigurationController.Instance.Configuration;
        }

        private void UpdateConfig() {
            ConfigurationController.Instance.Configuration = this.Settings;
        }


        private CrackConfiguration Settings {
            get {
                CrackConfiguration ThisConfig = new CrackConfiguration()
                {
                    TrueCryptBinaryPath = this.txtTrueCryptBinaryPath.Text,
                    ContainerPath = this.txtTargetVolume.Text,
                    MountAsSystemVolume = this.chkIsSystemVol.Checked,
                    WordListPath = this.txtWordListPath.Text,
                };
                int offset;
                if(Int32.TryParse(this.txtWordListOffset.Text, out offset)) {
                    ThisConfig.WordListOffset = offset;
                } else {
                    ThisConfig.WordListOffset = 0;
                }
                return ThisConfig;
            }
            set {
                this.txtTrueCryptBinaryPath.Text = value.TrueCryptBinaryPath;
                this.txtTargetVolume.Text = value.ContainerPath;
                this.chkIsSystemVol.Checked = value.MountAsSystemVolume;
                this.txtWordListPath.Text = value.WordListPath;
                this.txtWordListOffset.Text = value.WordListOffset.ToString();
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






    }
}
