using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using truecryptbrute.TrueCrypt.KeyFiles;

namespace truecryptbrute.TrueCrypt
{
    public class Password
    {
        #region Private Data

        const int MIN_PASSWORD = 1;		// Minimum possible password length
        const int MAX_PASSWORD = 64;	// Maximum possible password length
        private string password = "";
        private byte[] passwordBuffer = new byte[MAX_PASSWORD + 1]; // +1 !?
        private int usedBufLen = 0;

        private KeyfilePool appliedPool = null;

        #endregion

        #region Constructor

        public Password(string upassword) {
            password = upassword;
        }

        #endregion

        #region Password Structure

        /*
        typedef struct
        {
          // Modifying this structure can introduce incompatibility with previous versions
          unsigned __int32 Length;
          unsigned char Text[MAX_PASSWORD + 1];
         char Pad[3]; // keep 64-bit alignment
        } Password;
        */

        /// <summary>
        /// Generates the TrueCrypt.Password structure from the given Passphrase and the applied KeyPool (if any)
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public byte[] GetPasswordStructure() {

            this.SetupPasswordBuffer();
            
            var passwordStruct = new byte[4 + MAX_PASSWORD + 1 + 3];
            var passlen = BitConverter.GetBytes(usedBufLen);
            passlen.CopyTo(passwordStruct, 0);
            passwordBuffer.CopyTo(passwordStruct, 4);
            return passwordStruct;
        }

        private void SetupPasswordBuffer() {

            var passbytes = StringToByteArray(password, EncodingType.ASCII);
            usedBufLen = passbytes.Count();
            try {
                Array.Copy(passbytes, 0, passwordBuffer, 0, (passbytes.Count() > passwordBuffer.Length) ? passwordBuffer.Length : passbytes.Count()); //Copy max 64 password chars to the pass buffer
            } catch(Exception e) {
                e.ToString();
            }
            if(this.appliedPool != null)
                this.ApplyKeyDataPool();
        }

        /// <summary>
        /// Mixes the KeyFilePool Data with the password buffer
        /// </summary>
        /// <param name="pool"></param>
        private void ApplyKeyDataPool() {
            var poolSize = appliedPool.Data.Count();

            for(int i = 0; i < poolSize; i++) {
                if(i < this.PasswordText.Length)
                    passwordBuffer[i] += appliedPool.Data[i];
                else
                    passwordBuffer[i] = appliedPool.Data[i];
            }

            // Update used Buflen if necessary

            if(usedBufLen < appliedPool.Data.Count())
                usedBufLen = appliedPool.Data.Count();
        }

        #endregion

        #region Public Properties

        public string PasswordText {
            get { return password; }
            set { password = value; }
        }

        public KeyfilePool KeyDataPool {
            get { return appliedPool; }
            set { appliedPool = value; }
        }

        #endregion

        #region Encoding

        #region EncodingType enum
        /// <summary> 
        /// Encoding Types. 
        /// </summary> 
        public enum EncodingType 
        { 
            ASCII, 
            Unicode, 
            UTF7, 
            UTF8 
        } 
        #endregion 

        #region StringToByteArray 
        /// <summary> 
        /// Converts a string to a byte array using specified encoding. 
        /// </summary> 
        /// <param name="str">String to be converted.</param> 
        /// <param name="encodingType">EncodingType enum.</param> 
        /// <returns>byte array</returns> 
        public static byte[] StringToByteArray(string str, EncodingType encodingType) 
        { 
            System.Text.Encoding encoding=null; 
            switch (encodingType) 
            { 
                case EncodingType.ASCII: 
                    encoding= new System.Text.ASCIIEncoding(); 
                    break;    
                case EncodingType.Unicode:
                    encoding = new System.Text.UnicodeEncoding();
                    break;    
                case EncodingType.UTF7:
                    encoding = new System.Text.UTF7Encoding();
                    break;    
                case EncodingType.UTF8:
                    encoding = new System.Text.UTF8Encoding();
                    break;    
            } 
            return encoding.GetBytes(str); 
        } 
        #endregion

        public truecryptbrute.TrueCrypt.KeyFiles.KeyfilePool KeyfilePool {
            get {
                throw new System.NotImplementedException();
            }
            set {
            }
        }

        #endregion
    }
}
