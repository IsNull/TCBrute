using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace truecryptbrute.TrueCrypt.VolumeHeaders
{
    internal class VolumeHeaderFactoryFile : VolumeHeaderFactory
    {
        private string volumePath;

        public VolumeHeaderFactoryFile(string uvolumePath) {
            volumePath = uvolumePath;
        }

        public override VolumeHeader ReadEncryptedVolumeHeader() {
            return ReadVolumeHeaderEncrypted(0);
        }

        /// <summary>
        /// Reads out the TrueCrypt Volume Header (512 Bytes)
        /// </summary>
        /// <param name="headerOffset">Offset from file begin</param>
        /// <returns>VolumeHeader if successfull</returns>
        protected VolumeHeader ReadVolumeHeaderEncrypted(int headerOffset) {
            VolumeHeader header = null;
            using(var device = File.OpenRead(volumePath)) {
                try {
                    var tmpbuffer = new byte[512];
                    device.Read(tmpbuffer, headerOffset, 512);
                    header = new VolumeHeader(tmpbuffer);
                } catch(IOException) {
                    header = null;
                } finally {
                    if(device != null)
                        device.Close();
                }
            }
            return header;
        }
    }
}
