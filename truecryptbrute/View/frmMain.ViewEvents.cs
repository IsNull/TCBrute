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
    public delegate void GParameterDelegate<T>(T value);
    public delegate void SimpleDelegate();

    public partial class frmMain : Form
    {
        public event SimpleEventHandler StartCrackJob;
        public event SimpleEventHandler PauseCrackJob;

        private void btnDoCrack_Click(object sender, EventArgs e) {
            if(StartCrackJob != null)
                StartCrackJob(this, new EventArgs());

        }

        private void btnPause_Click(object sender, EventArgs e) {


        }


        #region Log

        public void LogAppend(List<string> Lines) {
            foreach(var Line in Lines)
                LogAppend(Line);
        }

        public void LogAppend(string Line) {
            if(this.InvokeRequired) {
                BeginInvoke(new GParameterDelegate<string>(LogAppend), new object[] { Line });
                return;
            } else {
                this.txtLog.AppendText(">> " + Line + Environment.NewLine);
            }
        }

        public void LogClear() {
            if(this.InvokeRequired) {
                BeginInvoke(new SimpleDelegate(LogClear));
                return;
            } else {
                this.txtLog.Clear();
            }
        }

        #endregion

        #region Progress

        public void SetProgress(int percent){

            if(this.InvokeRequired) {
                BeginInvoke(new GParameterDelegate<int>(SetProgress), new object[] { percent });
                return;
            } else {
                percent = (percent > 100) ? 100 : percent;
                percent = (percent < 0) ? 0 : percent;
                this.progressBar1.Value = percent;
            }
        }

        #endregion

        #region Button

        public void SetButtonStart(bool b){
            if(this.InvokeRequired) {
                BeginInvoke(new GParameterDelegate<bool>(SetButtonStart), new object[] { b });
                return;
            } else {
                this.btnDoCrack.Visible = b;
                this.btnPause.Visible = !b;
            }
        }

        public void SetButtonPause(bool b){
            if(this.InvokeRequired) {
                BeginInvoke(new GParameterDelegate<bool>(SetButtonPause), new object[] { b });
                return;
            } else {
                this.btnPause.Visible = b;
                this.btnDoCrack.Visible = !b;
            }
        }

        #endregion
    }
}
