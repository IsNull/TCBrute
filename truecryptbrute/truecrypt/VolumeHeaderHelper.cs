using System; 
using System.Linq;
using System.Text;
using truecrypt;
using System.IO;


namespace truecryptbrute.truecrypt
{
 
    public static class VolumeHeaderHelper
    {

        /// <summary>just for debuging purposes :)
        /// 
        /// </summary>
        /// <param name="volumepath"></param>
        /// <returns></returns>
        public static VolumeHeader ReadVolumeHeaderFromFile(string volumepath) {
            VolumeHeader Header = null;
            Stream device = null;
            try{
                device = File.OpenRead(volumepath);
                Header = ReadVolumeHeaderEncrypted(device, VolumeType.TC_VOLUME_TYPE_NORMAL);
            }catch(IOException e){
                throw;
            } finally {
                if(device != null)
                    device.Close();
            }
            return Header;
        }



        /// <summary>Reads out the TrueCrypt Volume Header (512 Bytes)
        /// 
        /// </summary>
        /// <param name="Device">Stream to read from</param>
        /// <param name="Type">Volume Type</param>
        /// <param name="buffer">out Volume Header</param>
        public static VolumeHeader ReadVolumeHeaderEncrypted(Stream Device, VolumeType Type) {

            var tmpbuffer = new byte[512];
            int hostSize = 0;
            int headerOffset;

            switch(Type) {
                case VolumeType.TC_VOLUME_TYPE_NORMAL:
                    headerOffset = 0;
                    break;

                case VolumeType.TC_VOLUME_TYPE_HIDDEN:
                    headerOffset = 512;
                    break;


                case VolumeType.TC_VOLUME_TYPE_HIDDEN_LEGACY:
                    headerOffset = hostSize - 512;
                    break;
                default:
                    throw new NotSupportedException();
            }
            Device.Read(tmpbuffer, headerOffset, 512);
            return new VolumeHeader(tmpbuffer);
        }

    }


}
