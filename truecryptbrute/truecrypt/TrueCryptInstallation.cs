using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace truecryptbrute.truecrypt
{
    public static class TrueCryptInstallation
    {

        public static string FindTrueCryptInstallation(){

            string TC_PATH = "";
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;

            try {
                if(os.Platform == PlatformID.Win32Windows) {
                    //This is a pre-NT version of Windows


                } else if(os.Platform == PlatformID.Win32NT) {
                    switch(vs.Major) {
                        case 3:
                        case 4:
                        case 5:
                            //NT 2K - XP


                            break;
                        case 6:
                            //Vista/7 
                            RegistryKey OurKey = Registry.ClassesRoot;
                            OurKey = OurKey.OpenSubKey(@"TrueCryptVolume\DefaultIcon", false);
                            TC_PATH = OurKey.GetValue("").ToString();
                            TC_PATH = TC_PATH.Substring(0, TC_PATH.IndexOf(","));
                            break;
                        default:
                            break;
                    }
                }
            } catch {
                TC_PATH = "";
            }
            return TC_PATH;
        }

    }
}
