using System; 
using System.Linq;
using System.Text;
using truecrypt;
using System.IO;


namespace truecryptbrute.TrueCrypt
{
 
    public static class VolumeHeaderHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volumePath"></param>
        /// <returns></returns>
        public static VolumeHeader ReadVolumeHeaderFromFile(string volumePath) {
            VolumeHeader Header = null;
            Stream device = null;
            try{
                device = File.OpenRead(volumePath);
                Header = ReadVolumeHeaderEncrypted(device, VolumeType.TC_VOLUME_TYPE_NORMAL);
            }catch(IOException){
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
        /// <param name="device">Stream to read from</param>
        /// <param name="type">Volume Type</param>
        /// <param name="buffer">out Volume Header</param>
        public static VolumeHeader ReadVolumeHeaderEncrypted(Stream device, VolumeType type) {

            var tmpbuffer = new byte[512];
            int hostSize = 0;
            int headerOffset;

            switch(type) {
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
            device.Read(tmpbuffer, headerOffset, 512);
            return new VolumeHeader(tmpbuffer);
        }

    }


}
