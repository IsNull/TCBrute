using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using truecryptbrute.WordList;
using truecryptbrute.truecrypt;
using System.Threading;

namespace truecryptbrute
{
    public class truecryptbruter
    {
        ConfigurationController ConfigController;
        //WordListProvider WordListManager;
        frmMain MainForm;
        [ThreadStatic]List<string> InternalReservedMountLetter = new List<string>();



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
            Thread CrackThread = new Thread(new ThreadStart(StartCrackOperation));
            CrackThread.Start();
            MainForm.LogAppend("crackthread started running");
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

            Crack(CreateTrueCrypMounter(ConfigController.Configuration));
        }


        private void Crack(TrueCrypMounter TCM){
            string thispass;
            while((thispass = WordListProvider.Instance.NextPassword()) != null){
                if(TCM.MountTimeOut(thispass)) {
                    MessageBox.Show("volume cracked with pass: " + thispass);
                    break;
                } else {
                    MainForm.LogAppend("failed password " + thispass);
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

            var StartInfo = new System.Diagnostics.ProcessStartInfo();
            StartInfo.FileName = config.TrueCryptBinaryPath;

            truecrypt.TrueCrypMounter Instance = new TrueCrypMounter(StartInfo, Arg);

            return Instance;
        }



        public string FindNextAvailableDriveLetter() {

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
                AvaiableDriveList.Remove(drive.Substring(0,1).ToLower());
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
