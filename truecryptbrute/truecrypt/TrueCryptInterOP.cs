using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace truecryptbrute.TrueCrypt
{
    
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
    public struct TCHeaderData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)] 
        public byte[] Data;
    }


    public static class TrueCryptInterOP
    {       
        [DllImport("truecrypt.dll",CallingConvention=CallingConvention.StdCall,ExactSpelling=true)]
        public static extern int CheckVolumeHeaderPassword([MarshalAs(UnmanagedType.Bool)]bool bBoot, IntPtr pEncryptedVolumeHeader, [MarshalAs(UnmanagedType.LPArray)]byte[] PasswordStructure);
    }
}
