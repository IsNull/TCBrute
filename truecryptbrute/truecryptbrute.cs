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
        List<string> InternalReservedMountLetter = new List<string>();
        bool bStopAllCrackThreads = false;
        Stopwatch PerformanceWatch;

        public truecryptbruter()
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
            PrepareCrackOperation(); // go for it ;)
        }


        public void PrepareCrackOperation() {
            List<string> Descr;

            MainForm.LogClear();
            MainForm.LogAppend("Prepare new crack Operation...");
            ConfigController = ConfigurationController.Instance;
            if(!ConfigController.ValidateConfiguration(out Descr)) {
                MainForm.LogAppend(Descr);
                MainForm.LogAppend("Resolve the above errors and try again. Operation aborted.");
                return;
            }
            MainForm.LogAppend("Configuration seems valid.");
            MainForm.LogAppend("Analyzing Wordlist...");
            WordListProvider.Instance.LoadWordList(ConfigController.Configuration.WordListPath);
            WordListProvider.Instance.WordListProgressEvent +=new WordListProgressEventHandler(Instance_WordListProgressEvent);
            WordListLineCnt = WordListProvider.Instance.LineCount;
            MainForm.LogAppend("Wordlist anaysis: " + WordListProvider.Instance.LineCount + " Passwords!");

            // Start the Crack Threads:
            Thread CrackThread = new Thread(new ThreadStart(CrackThreadEntryPoint));
            Thread CrackThread2 = new Thread(new ThreadStart(CrackThreadEntryPoint));
            PerformanceWatch = Stopwatch.StartNew();
            CrackThread.Start();
            CrackThread2.Start();

            PerformanceWatch.Start();
        }


        private void CrackThreadEntryPoint() {

            var TCMounter = CreateTrueCrypMounter(ConfigController.Configuration);

            var executableName = Application.ExecutablePath;
            var executableFile = new FileInfo(executableName);
            var TrueCryptBinaryFile = new FileInfo(TCMounter.InstanceStartUpInfo.FileName);
            var executableDirectoryName = executableFile.DirectoryName;

            var NewTrueCryptThreadBinary = executableDirectoryName + "\\" + TrueCryptBinaryFile.Name + "TCB_" + Thread.CurrentThread.ManagedThreadId + ".exe";
            if(!File.Exists(NewTrueCryptThreadBinary)) {
                TrueCryptBinaryFile.CopyTo(NewTrueCryptThreadBinary);
            }
            TCMounter.InstanceStartUpInfo.FileName = NewTrueCryptThreadBinary;
            
            MainForm.LogAppend("TEP{" + Thread.CurrentThread.ManagedThreadId + "}: Starting Crack Thread @" + TCMounter.TrueCryptArgument.MountLetter.ToUpperInvariant() + " destination.");
            Crack(TCMounter);
        }

        private void PasswordCracked(string thispass, string volumeletter) {
            PerformanceWatch.Stop();
            bStopAllCrackThreads = true;
            MainForm.LogAppend("Cracked with password: " + thispass);

            MainForm.LogAppend("This Crack took ms: " + PerformanceWatch.ElapsedMilliseconds);

            View.frmPassCracked DlgPassCracked = new View.frmPassCracked(thispass);
            DlgPassCracked.ShowDialog();
        }


        private void Instance_WordListProgressEvent(object sender, WordListEventArgs e){
            MainForm.SetProgress(100 / WordListLineCnt * e.WordListCurrentLine);
        }

        private void Crack(TrueCrypMounter TCM){
            string thispass;
            while((thispass = WordListProvider.Instance.NextPassword()) != null  && !bStopAllCrackThreads){
                if(TCM.MountTimeOut(thispass)) {
                    PasswordCracked(thispass, "unknown");
                    break;
                } else {
                    //failed pass
                    //MainForm.LogAppend("CT{" + Thread.CurrentThread.ManagedThreadId + "} failed pass: " + thispass);
                }
            }

        }



        private TrueCrypMounter CreateTrueCrypMounter(CrackConfiguration config){

            TrueCryptArgument Arg = new TrueCryptArgument();
            Arg.IsSystemPartition = config.MountAsSystemVolume;
            Arg.MountLetter = FindNextAvailableDriveLetter();
            Arg.VolumePath = config.ContainerPath;
            Arg.Quit = true;
            Arg.Silent = true;
            Arg.ReadOnly = true;

            var StartInfo = new System.Diagnostics.ProcessStartInfo();
            StartInfo.FileName = config.TrueCryptBinaryPath;

            truecrypt.TrueCrypMounter Instance = new TrueCrypMounter(StartInfo, Arg);

            return Instance;
        }



        public string FindNextAvailableDriveLetter() {
            lock(this) {
                var AvaiableDriveList = new List<string>(25);

                int lowerBound = Convert.ToInt16('d');
                int upperBound = Convert.ToInt16('z');
                for(int i = lowerBound; i < upperBound; i++) {
                    char driveLetter = (char)i;
                    AvaiableDriveList.Add(driveLetter.ToString());
                }

                // remove all already used drives
                string[] drives = Environment.GetLogicalDrives();
                foreach(string drive in drives) {
                    AvaiableDriveList.Remove(drive.Substring(0, 1).ToLower());
                }

                // remove all Internaly reserved Drives
                foreach(var drive in InternalReservedMountLetter) {
                    AvaiableDriveList.Remove(drive.ToLower());
                }

                if(AvaiableDriveList.Count > 0) {
                    InternalReservedMountLetter.Add(AvaiableDriveList[0]);
                    return AvaiableDriveList[0];
                } else {
                    throw (new ApplicationException("No free drives available."));
                }
            }
        }

    }
}
