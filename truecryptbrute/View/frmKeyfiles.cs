using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace truecryptbrute.View
{
    public partial class frmKeyfiles : Form
    {
        private List<string> LVData = null;

        public frmKeyfiles(List<string> KeyFiles = null)
        {
            InitializeComponent();
            if (KeyFiles != null)
            {
                this.KeyFiles = KeyFiles;
            }
        }

        public List<string> KeyFiles
        {
            get
            {
                CollectData();
                return LVData;
            }
            set
            {
                ListViewItem lvi;
                listView1.Items.Clear();
                foreach (var file in value)
                {
                    lvi = new ListViewItem();
                    lvi.Text = file;
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void CollectData() {
            if(listView1.InvokeRequired) {
                BeginInvoke(new SimpleDelegate(CollectData));
            } else {
                LVData = new List<string>();
                foreach(ListViewItem item in listView1.Items) {
                    LVData.Add(item.Text);
                }
            }
        }


        private void btnAddKeyfile_Click(object sender, EventArgs e) {
            OpenFileDialog DlgOpenFile = new OpenFileDialog();
            DlgOpenFile.Multiselect = true;
            if(DlgOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                ListViewItem lvi;
                foreach(var file in DlgOpenFile.FileNames) {
                    lvi = new ListViewItem();
                    lvi.Text = file;
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            foreach(ListViewItem selitem in listView1.SelectedItems)
                listView1.Items.Remove(selitem);
        }
    }
}
