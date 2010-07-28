using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using truecryptbrute.WordList;
using truecryptbrute.truecrypt;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace truecryptbrute
{
    public class truecryptbruter
    {
        ConfigurationController ConfigController;
        //WordListProvider WordListManager;
        frmMain MainForm;
        int WordListLineCnt;
        bool bStopAllCrackThreads = false;
        bool bIsCrackOperationFinished = true;
        Stopwatch PerformanceWatch;
        Stopwatch PerformanceWatchInDLL = new Stopwatch();
        VolumeHeader header;
        List<Thread> crackthreadlist = new List<Thread>();

        public truecryptbruter()
        {
            ConfigController = new ConfigurationController();
        }

        public void ShowMainGUI() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new frmMain();

            MainForm.StartCrackJob += new SimpleEventHandler(MainForm_StartCrackJob);
            MainForm.PauseCrackJob +=new SimpleEventHandler(MainForm_PauseCrackJob);
            MainForm.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            Application.Run(MainForm);
        }


        private void MainForm_StartCrackJob(object sender, EventArgs e) {
            MainForm.SetButtonStart(false);

            if(bIsCrackOperationFinished) {
                if(PrepareCrackOperation()) {  // set up new crack operation
                    StartWork(); // go for it ;)  
                }
            } else {
                StartWork(); // go for it ;)  
            }

        }

        private void MainForm_PauseCrackJob(object sender, EventArgs e) {
            StopAllCrackThreads();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }



        public bool PrepareCrackOperation() {
            List<string> Descr;

            MainForm.LogClear();
           
            MainForm.LogAppend("Prepare new crack Operation...");
            ConfigController.Configuration = MainForm.CrackConfig;
            if(!ConfigController.ValidateConfiguration(out Descr)) {
                MainForm.LogAppend(Descr);
                MainForm.LogAppend("Resolve the above errors and try again. Operation aborted.");
                MainForm.SetButtonStart(true);
                return false;
            }
            MainForm.LogAppend("Configuration seems valid.");
            MainForm.LogAppend("Analyzing Wordlist...");
            WordListProvider.Instance.LoadWordList(ConfigController.Configuration.WordListPath);
            WordListProvider.Instance.WordListProgressEvent +=new WordListProgressEventHandler(Instance_WordListProgressEvent);
            WordListLineCnt = WordListProvider.Instance.LineCount;
            MainForm.LogAppend("Wordlist anaysis: " + WordListProvider.Instance.LineCount + " Passwords!");

            try {
                header = VolumeHeaderHelper.ReadVolumeHeaderFromFile(ConfigController.Configuration.ContainerPath);
            } catch(IOException e) {
                MessageBox.Show("Can't read Volume Header: " + e.Message);
                MainForm.LogAppend("Flow interrupted!");
                return false;
            }
            return true;
        }


        /// <summary>This Method starts the Threads. It can even be used to resume the work, as we have set globally definded our wordlist calss wich handles the password flow.
        /// 
        /// </summary>
        private void StartWork(){
            Thread CrackThread;

            MainForm.LogAppend("Starting Crack Threads...");

            bStopAllCrackThreads = false;
            bIsCrackOperationFinished = false;

            int thread_count = ConfigController.Configuration.ThreadCount;

            PerformanceWatch = Stopwatch.StartNew();
            PerformanceWatch.Start();
            for(int i = 1; thread_count >= i; i++) {
                CrackThread = new Thread(new ThreadStart(CrackThreadEntryPoint));
                crackthreadlist.Add(CrackThread);
                CrackThread.Start();
            }
        }


        /// <summary>
        /// This is the Main EP for the Crack Threads
        /// </summary>
        private void CrackThreadEntryPoint() {
            MainForm.LogAppend("TEP{" + Thread.CurrentThread.ManagedThreadId + "}: Starting Crack Thread...");
            Crack();
        }

        private void Crack(){
            string thispass;

            while((thispass = WordListProvider.Instance.NextPassword()) != null && !bStopAllCrackThreads) {

                if(header.DecryptVolumeHeader(ClsPassword.GetPasswordStructure(thispass))) {
                    PasswordCracked(thispass);
                    break;
                } else {
                    // failed pass
                }
            }
            if(thispass == null) {
                WordListFinished();
            } else {
                bIsCrackOperationFinished = true;
                ThreadStoped();
            }
        }


        private void StopAllCrackThreads() {

            bStopAllCrackThreads = true;
            PerformanceWatch.Stop();
            MainForm.LogAppend("Stoping crack threads... ");
            MainForm.LogAppend("Elapsed Time: " + PerformanceWatch.ElapsedMilliseconds);
            
            MainForm.SetButtonStart(true);
        }

        private void PasswordCracked(string thispass) {
            StopAllCrackThreads();
            bIsCrackOperationFinished = true;
            MainForm.LogAppend("Password Cracked! " + thispass);
            View.frmPassCracked DlgPassCracked = new View.frmPassCracked(thispass);
            DlgPassCracked.ShowDialog();
        }

        private void WordListFinished() {
            //StopAllCrackThreads();
            bIsCrackOperationFinished = true;
            MainForm.LogAppend("Password not found withhin this wordlist. ");
        }

        private void ThreadStoped() {
            MainForm.LogAppend("Thread stopped for reason.");
        }

        private void SuspendCrackThreads() {
            
            foreach(var thread in crackthreadlist) {
                thread.Suspend();
            }
        }
        private void ResumeCrackThreads() {
            
            foreach(var thread in crackthreadlist) {
                thread.Resume();
            }
        }


        private void Instance_WordListProgressEvent(object sender, WordListEventArgs e) {
            MainForm.SetProgress(e);
        }



    }
}
