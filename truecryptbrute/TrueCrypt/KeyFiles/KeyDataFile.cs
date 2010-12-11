using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace truecryptbrute.TrueCrypt.KeyFiles
{
    public class KeyDataFile : IKeyData
    {

        string filePath = "";

        public KeyDataFile(string uPath) {
            filePath = uPath;
        }

        public string FilePath {
            get { return filePath; }
            set { filePath = value; }
        }

        public byte[] GetKeyData() {
            var buf = new byte[0];
            using(var fs = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read)) {
                using(var br = new BinaryReader(fs)) {
                    buf = br.ReadBytes(KeyFileSettings.KEYFILE_MAX_READ_LEN);
                }
            }
            return buf;
        }
    }
}
