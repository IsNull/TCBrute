using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace truecryptbrute
{
    /// <summary>ConfigurationController (Singleton)
    /// 
    /// </summary>
    public sealed class ConfigurationController
    {
        static readonly ConfigurationController mInstance = new ConfigurationController();
        XmlSerializer CrackConfigSerializer = new XmlSerializer(typeof(CrackConfiguration));


        static ConfigurationController() { }
        ConfigurationController() { }

        public static ConfigurationController Instance
        {
            get { return mInstance; }
        }


        private CrackConfiguration mConfiguration;
        public CrackConfiguration Configuration
        {
            get { return mConfiguration; }
            set { mConfiguration = value; }
        }

        public void SaveCrackConfiguration(string DestinationPath){
            Stream FileStream = File.OpenWrite(DestinationPath);
            CrackConfigSerializer.Serialize(FileStream, mConfiguration);
            FileStream.Close();
        }

        public bool LoadCrackConfiguration(string DestinationPath)
        {
            bool sucess = false;
            if(File.Exists(DestinationPath)) {
                Stream FileStream = File.OpenRead(DestinationPath);
                try {
                    mConfiguration = (CrackConfiguration)CrackConfigSerializer.Deserialize(FileStream);
                    sucess = true;
                } catch {
                    sucess = false;
                } finally {
                    FileStream.Close();
                }
            } else {
                throw new System.IO.FileNotFoundException();
            }
            return sucess;
        }


        public bool ValidateConfiguration() {
            List<string> dummy;
            return ValidateConfiguration(out dummy);
        }
        /// <summary>Validates the Crack Configuration
        /// 
        /// </summary>
        /// <param name="ValidationResult">String ErrorDescription</param>
        /// <returns>true/false</returns>
        public bool ValidateConfiguration(out List<string> ValidationResult) {
            ValidationResult = new List<string>();
            bool sucess = true;

            if(!File.Exists(this.Configuration.TrueCryptBinaryPath)) {
                ValidationResult.Add("Can't find TrueCrypt Binary @ \"" + this.Configuration.TrueCryptBinaryPath + "\"");
                sucess = false;
            }
            if(!File.Exists(this.Configuration.WordListPath)) {
                ValidationResult.Add("Can't find WordList @ \"" + this.Configuration.WordListPath + "\"");
                sucess = false;
            }
            if(!File.Exists(this.Configuration.ContainerPath)) {
                ValidationResult.Add("Can't find Target Volume @ \"" + this.Configuration.ContainerPath + "\"");
                sucess = false;
            }

            foreach(var keyfilepath in this.Configuration.KeyFiles) {
                if(!File.Exists(keyfilepath)){
                    ValidationResult.Add("Can't find Keyfile @ \"" + keyfilepath + "\"");
                    sucess = false;
                }
            }

            return sucess;
        }

    }
}
