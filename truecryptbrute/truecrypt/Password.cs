using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecryptbrute.truecrypt
{
    public static class ClsPassword
    {
        const int MIN_PASSWORD = 1;		// Minimum possible password length
        const int MAX_PASSWORD = 64;	// Minimum possible password length


        public static byte[] GetPasswordStructure(string password) {

            var PasswordStructure = new byte[72];
            var passbytes = StringToByteArray(password, EncodingType.ASCII);
            var passlen = BitConverter.GetBytes(passbytes.Length);

            passlen.CopyTo(PasswordStructure, 0);
            passbytes.CopyTo(PasswordStructure, 4);
            return PasswordStructure;

        }



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
                    encoding=new System.Text.ASCIIEncoding(); 
                    break;    
                case EncodingType.Unicode: 
                    encoding=new System.Text.UnicodeEncoding(); 
                    break;    
                case EncodingType.UTF7: 
                    encoding=new System.Text.UTF7Encoding(); 
                    break;    
                case EncodingType.UTF8: 
                    encoding=new System.Text.UTF8Encoding(); 
                    break;    
            } 
            return encoding.GetBytes(str); 
        } 
        #endregion


    }
}
