using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecryptbrute.TrueCrypt.VolumeHeaders
{
    class VolumeHeaderFactoryFileHidden : VolumeHeaderFactoryFile
    {
        public VolumeHeaderFactoryFileHidden(string uvolumePath) 
            : base(uvolumePath) { }

        public override VolumeHeader ReadEncryptedVolumeHeader() {
            return ReadVolumeHeaderEncrypted(64 * 1024);
        }
    }
}
