using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using truecryptbrute.WordList;


namespace truecryptbrute
{
    public class truecryptbrute
    {
        ConfigurationController ConfigController;
        WordListProvider WordListManager;
        frmMain MainForm;


        public truecryptbrute()
        {
            ConfigController = ConfigurationController.Instance;
        }

        public void ShowMainGUI() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new frmMain();

            MainForm.StartCrackJob += new SimpleEventHandler(MainForm_StartCrackJob);

            Application.Run(MainForm);
        }


        private void MainForm_StartCrackJob(object sender, EventArgs e) {
            StartCrackOperation();
        }


        public void StartCrackOperation() {
            List<string> Descr;

            MainForm.LogClear();
            ConfigController = ConfigurationController.Instance;
            if(!ConfigController.ValidateConfiguration(out Descr)) {
                MainForm.LogAppend(Descr);
                return;
            }
            MainForm.LogAppend("Configuration seems valid.");
            WordListProvider.Instance.LoadWordList(ConfigController.Configuration.WordListPath);
            MainForm.LogAppend("Wordlist anaysis: " + WordListProvider.Instance.LineCount + " Passwords!");



        }


    }
}
