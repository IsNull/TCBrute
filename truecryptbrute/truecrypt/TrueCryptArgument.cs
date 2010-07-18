using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecryptbrute.truecrypt
{

    public class TrueCryptArgument
    {
        #region const strings

        const string param_volume = @"/v";
        const string param_letter = @"/l";
        const string param_keyfile = @"/k";
        const string param_password = @"/p";
        const string param_mount = @"/m";
        const string param_quit = @"/q";
        const string param_silent = @"/s";

        const string param_mntsystem = "sm";

        #endregion

        #region Propertys

        private string mVolumePath = "";
        private string mMountLetter = "";
        private string mPassword = "";
        private bool mIsSystemPartition = false;
        private bool mSilent = true;
        private bool mQuit = true;
        private List<string> mKeyFileLst = new List<string>();  
        public string VolumePath
        {
            get { return mVolumePath; }
            set { mVolumePath = value; }
        }
        public string MountLetter
        {
            get { return mMountLetter; }
            set { mMountLetter = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        public List<string> KeyFileLst
        {
            get { return mKeyFileLst; }
            set { mKeyFileLst = value; }
        }

        public bool IsSystemPartition
        {
            get { return mIsSystemPartition; }
            set { mIsSystemPartition = value; }
        }
        public bool Silent
        {
            get { return mSilent; }
            set { mSilent = value; }
        }
        public bool Quit
        {
            get { return mQuit; }
            set { mQuit = value; }
        }

        #endregion

        /// <summary>Build the Argument String from the given Options
        /// 
        /// </summary>
        public string ArgumentString
        {
            get
            {

                string ArgumentString = param_volume + " \"" + this.VolumePath + "\" ";
                ArgumentString += param_letter + " \"" + this.MountLetter + "\" ";
                
                foreach (var keyfilepath in this.KeyFileLst)
                {
                    ArgumentString += param_keyfile + " \"" + keyfilepath + "\" ";
                }

                if (this.IsSystemPartition)
                    ArgumentString += param_mount + " " + param_mntsystem + " ";

                ArgumentString += param_password + " " + this.Password + " ";

                if (this.Quit)
                    ArgumentString += param_quit + " ";

                if (this.Silent)
                    ArgumentString += param_silent + " ";

                return ArgumentString;
            }
        }
    }
}
