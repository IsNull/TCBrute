using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecryptbrute.TrueCrypt.KeyFiles
{
    public interface IKeyData
    {
        byte[] GetKeyData();
    }
}
