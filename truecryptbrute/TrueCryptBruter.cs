using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using truecryptbrute.View;
using truecryptbrute.WordList;
using truecryptbrute.TrueCrypt;
using System.Threading;
using System.IO;
using System.Diagnostics;
using truecryptbrute.TrueCrypt.KeyFiles;
using truecryptbrute.TrueCrypt.VolumeHeaders;
using truecryptbrute.Wordlist;

namespace truecryptbrute
{
    public class TrueCryptBruter
    {
        #region Private Data

        ConfigurationController config;
        FrmMain mainForm;
        int wordListLineCnt;
        bool bStopAllCrackThreads = false;
        bool bIsCrackOperationFinished = true;
        Stopwatch performanceWatch;
        Stopwatch performanceWatchInDLL = new Stopwatch();
        VolumeHeader header;
        List<Thread> crackthreadlist = new List<Thread>();

        KeyfilePool keyDataPool = new KeyfilePool();

        #endregion

        public TrueCryptBruter()
        {
            config = new ConfigurationController();
        }

        public void ShowMainGUI() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new FrmMain();

            mainForm.StartCrackJob += new SimpleEventHandler(MainForm_StartCrackJob);
            mainForm.PauseCrackJob +=new SimpleEventHandler(MainForm_PauseCrackJob);
            mainForm.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            Application.Run(mainForm);
        }


        private void MainForm_StartCrackJob(object sender, EventArgs e) {
            mainForm.SetButtonStart(false);

            if(bIsCrackOperationFinished) {
                if(PrepareCrackOperation()) {
                    StartWork();
                }
            } else {
                StartWork(); 
            }
        }

        private void MainForm_PauseCrackJob(object sender, EventArgs e) {
            StopAllCrackThreads();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            //StopAllCrackThreads();
            //Application.Exit();
            Environment.Exit(0);
        }



        public bool PrepareCrackOperation() {
            List<string> descr;

            mainForm.LogClear();
           
            mainForm.LogAppend("Prepare new crack Operation...");
            config.Configuration = mainForm.CrackConfig;
            if(!config.ValidateConfiguration(out descr)) {
                mainForm.LogAppend(descr);
                mainForm.LogAppend("Resolve the above errors and try again. Operation aborted.");
                mainForm.SetButtonStart(true);
                return false;
            }
            mainForm.LogAppend("Configuration seems valid.");
            mainForm.LogAppend("Analyzing Wordlist...");
            WordListPasswordProvider.Instance.LoadWordList(config.Configuration.WordListPath);
            if (config.Configuration.WordListOffset > 0)
            {
                WordListPasswordProvider.Instance.StartingLine = config.Configuration.WordListOffset;
            }
            wordListLineCnt = WordListPasswordProvider.Instance.PasswordCount;
            mainForm.LogAppend("Wordlist anaysis: " + WordListPasswordProvider.Instance.PasswordCount + " Passwords!");

            // chose the volume extraction mode
            VolumeHeaderFactory volumeHeaderExtractor;
            if(!config.Configuration.AttackHiddenVolume)
                volumeHeaderExtractor = new VolumeHeaderFactoryFile(config.Configuration.ContainerPath);
            else
                volumeHeaderExtractor = new VolumeHeaderFactoryFileHidden(config.Configuration.ContainerPath);
            

            // Setup Keydata Pool
            if(config.Configuration.UseKeyFiles) {
                mainForm.LogAppend("Setting up Keypool...");
                foreach(var path in config.Configuration.KeyFiles){
                    keyDataPool.AddKeyfile(new KeyDataFile(path));
                    mainForm.LogAppend(path);
                }
                keyDataPool.FinalizeKeyDataPool();
            }

            try {
                header = volumeHeaderExtractor.ReadEncryptedVolumeHeader();
            } catch(IOException e) {
                MessageBox.Show("Can't read Volume Header: " + e.Message);
                mainForm.LogAppend("Flow interrupted!");
                return false;
            }

            return true;
        }


        /// <summary>This FinalizeKeyDataPool starts the Threads. It can even be used to resume the work, as we have set globally definded our wordlist calss wich handles the password flow.
        /// 
        /// </summary>
        private void StartWork(){
            Thread CrackThread;

            mainForm.LogAppend("Starting Crack Threads...");
            mainForm.StartProgressTimer();

            bStopAllCrackThreads = false;
            bIsCrackOperationFinished = false;

            int thread_count = config.Configuration.ThreadCount;

            performanceWatch = Stopwatch.StartNew();
            performanceWatch.Start();
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
            mainForm.LogAppend("TEP{" + Thread.CurrentThread.ManagedThreadId + "}: Starting Crack Thread...");
            Crack();
        }

        private void Crack(){
            string thispass;
            Password pass;

            while((thispass = WordListPasswordProvider.Instance.NextPassword()) != null && !bStopAllCrackThreads) {

                pass = new Password(thispass);

                if(config.Configuration.UseKeyFiles)
                    pass.KeyfilePool = keyDataPool;
                
                if(header.DecryptVolumeHeader(pass.GetPasswordStructure())) {
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


        private void StopAllCrackThreads()
        {
            mainForm.StopProgressTimer();

            bStopAllCrackThreads = true;
            if(performanceWatch != null)
                performanceWatch.Stop();
            mainForm.LogAppend("Stoping crack threads... ");
            mainForm.LogAppend("Elapsed Time: " + performanceWatch.ElapsedMilliseconds);
            
            mainForm.SetButtonStart(true);
        }

        private void PasswordCracked(string thispass) {
            StopAllCrackThreads();
            bIsCrackOperationFinished = true;
            mainForm.LogAppend("Password Cracked! " + thispass);
            View.frmPassCracked DlgPassCracked = new View.frmPassCracked(thispass);
            DlgPassCracked.ShowDialog();
        }

        private void WordListFinished() {
            //StopAllCrackThreads();
            bIsCrackOperationFinished = true;
            mainForm.LogAppend("Password not found withhin this wordlist. ");
        }

        private void ThreadStoped() {
            mainForm.LogAppend("Thread stopped for reason.");
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
    }
}
