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
            return ReadVolumeHeaderEncrypted(TrueCryptAPI.TC_VOLUME_HEADER_OFFSET);
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
                    var tmpbuffer = new byte[TrueCryptAPI.TC_VOLUME_HEADER_EFFECTIVE_SIZE];
                    device.Seek(headerOffset, SeekOrigin.Begin);
                    device.Read(tmpbuffer, 0, tmpbuffer.Length);
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
