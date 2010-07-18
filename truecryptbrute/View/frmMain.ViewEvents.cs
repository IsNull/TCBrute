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
    public delegate void SimpleEventHandler(object sender, EventArgs e);

    public partial class frmMain : Form
    {
        public event SimpleEventHandler StartCrackJob;
        public event SimpleEventHandler PauseCrackJob;

        private void btnDoCrack_Click(object sender, EventArgs e) {
            if(StartCrackJob != null)
                StartCrackJob(this, new EventArgs());
        }

        public void LogAppend(List<string> Lines) {
            foreach(var Line in Lines)
                LogAppend(Line);
        }

        public void LogAppend(string Line) {
            this.txtLog.AppendText(">> " + Line + Environment.NewLine);
        }
        public void LogClear() {
            this.txtLog.Clear();
        }

    }
}
