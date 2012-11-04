using System;
using System.Collections.Generic;
using System.Windows.Forms;
using truecryptbrute.Wordlist;

namespace truecryptbrute.View
{
    public delegate void SimpleEventHandler(object sender, EventArgs e);
    public delegate void GParameterDelegate<T>(T value);
    public delegate void SimpleDelegate();

    public partial class FrmMain : Form
    {
        public event SimpleEventHandler StartCrackJob;
        public event SimpleEventHandler PauseCrackJob;

        private ConfigurationController ConfigController = new ConfigurationController();

        private void btnDoCrack_Click(object sender, EventArgs e) {
            if(StartCrackJob != null)
                StartCrackJob(this, new EventArgs());

        }

        private void btnPause_Click(object sender, EventArgs e) {
            if(PauseCrackJob != null)
                PauseCrackJob(this, new EventArgs());
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

        public void SetProgress(PasswordProgressEventArgs e)
        {

            if(this.InvokeRequired) {
                BeginInvoke(new GParameterDelegate<PasswordProgressEventArgs>(SetProgress), new object[] { e });
                return;
            } else {
                float full = e.WordListLineCount;
                float current = e.WordListCurrentLine;
                int percent = (int)(100f / full * current);
                percent = (percent > 100) ? 100 : percent;
                percent = (percent < 0) ? 0 : percent;
                this.progressBar1.Value = (int)percent;
                this.txtCurrentPass.Text = e.WordListCurrentPass;
                this.lblProgress.Text = e.WordListCurrentLine + "/" + e.WordListLineCount + "[" + percent + "%]";
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
