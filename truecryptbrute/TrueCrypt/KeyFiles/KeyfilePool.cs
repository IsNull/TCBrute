using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using truecryptbrute.Crypto;


namespace truecryptbrute.TrueCrypt.KeyFiles
{
    /// <summary>
    /// Represents the Keyfile Data Pool from all keyfiles/keytokens used.
    /// </summary>
    public class KeyfilePool
    {
        #region Private Data
        
        private List<IKeyData> keyfiles = new List<IKeyData>();
        private byte[] keyPool = null;

        #endregion

        #region Pulbic KeyPool Methods
        /// <summary>
        /// Creates the KeyData Pool
        /// </summary>
        public void FinalizeKeyDataPool() {
            byte[] buf;
            int bytesRead;
            uint crc;
            int writePos;

            keyPool = new byte[KeyFileSettings.KEYFILE_POOL_SIZE];

            foreach(var kf in keyfiles) {

                buf = kf.GetKeyData();
                bytesRead = buf.Count();
                crc = 0xffffffff;
                writePos = 0;

                for (int i = 0; i < bytesRead; i++){

                    crc = CRC32.UPDC32(buf[i] , crc);
                    keyPool[writePos++] += (byte) (crc >> 24);
			        keyPool[writePos++] += (byte) (crc >> 16);
			        keyPool[writePos++] += (byte) (crc >> 8);
                    keyPool[writePos++] += (byte) crc;

                    if(writePos >= KeyFileSettings.KEYFILE_POOL_SIZE)
                        writePos = 0;
                }
            }
        }
        #endregion

        #region Public Properties

        public byte[] Data {
            get { return keyPool; }
        }

        public IKeyData[] KeyDataFiles {
            get { return keyfiles.ToArray(); }
        }

        #endregion

        #region Public KeyData Handling

        public void AddKeyfile(IKeyData kf) {
            keyfiles.Add(kf);
        }

        public void RemoveKeyfile(IKeyData kf) {
            keyfiles.Remove(kf);
        }

        #endregion
    }
}
