using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecryptbrute.TrueCrypt.VolumeHeaders
{
    internal abstract class VolumeHeaderFactory
    {
        public abstract VolumeHeader ReadEncryptedVolumeHeader();
    }
}
