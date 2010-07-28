using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace truecryptbrute.truecrypt
{
    

    public class VolumeHeader
    {
        public const int TC_VOLUMEHEADER_EFFECTIVE_SIZE = 512;

        private TCHeaderData TCHeaderDataStruct = new TCHeaderData();
        private IntPtr HeaderStructPointer;
        


        #region Constructor

        public VolumeHeader(byte[] buffer) {
            if(buffer.Length == TC_VOLUMEHEADER_EFFECTIVE_SIZE) {
                TCHeaderDataStruct.Data = new byte[TC_VOLUMEHEADER_EFFECTIVE_SIZE];
                buffer.CopyTo(TCHeaderDataStruct.Data, 0);

                HeaderStructPointer = Marshal.AllocHGlobal(TC_VOLUMEHEADER_EFFECTIVE_SIZE);
                Marshal.StructureToPtr(TCHeaderDataStruct, HeaderStructPointer, true);          
            } else {
                throw new FieldAccessException("Volumeheader buffer has invalid length!");
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PasswordStructure">With Keyfiles applied to it!</param>
        /// <returns></returns>
        public bool DecryptVolumeHeader(byte[] PasswordStructure){
            TCErrorCode Status;

            var ret = TrueCryptInterOP.CheckVolumeHeaderPassword(false, HeaderStructPointer, PasswordStructure);
            
            if(Enum.IsDefined(typeof(TCErrorCode), ret)){
                Status = (TCErrorCode)ret;
            }else{
                throw new NotSupportedException();
            }

            switch(Status) {

                case TCErrorCode.ERR_SUCCESS:
                    return true;

                case TCErrorCode.ERR_PASSWORD_WRONG:
                    return false;

                default:
                    throw new TCException(Status);
            }

        }

    }
}
