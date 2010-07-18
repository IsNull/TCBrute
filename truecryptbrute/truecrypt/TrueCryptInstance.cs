using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace truecryptbrute.truecrypt
{
    public class TrueCrypMounter
    {
        public int ProcessTimeOut = 5000;
        public  ProcessStartInfo InstanceStartUpInfo;
        public TrueCryptArgument TrueCryptArgument;

        public TrueCrypMounter(ProcessStartInfo uSettings, TrueCryptArgument uTrueCryptArgument)
        {
            InstanceStartUpInfo = uSettings;
            TrueCryptArgument = uTrueCryptArgument;
        }


        public bool MountTimeOut(string password)
        {
            if (!DriveExist(TrueCryptArgument.MountLetter))
            {
                TrueCryptArgument.Password = password;
                InstanceStartUpInfo.Arguments = TrueCryptArgument.ArgumentString;
                try
                {
                    var Instance = Process.Start(InstanceStartUpInfo);
                    Instance.WaitForExit(ProcessTimeOut);

                    if(!Instance.HasExited) {
                        Instance.Kill();
                    }

                    if(DriveExist(TrueCryptArgument.MountLetter)) {
                        return true;
                    } else {
                        return false;
                    }

                } catch(System.IO.FileNotFoundException) {
                    throw;
                }
            } else {
                throw new DriveLetterNotFreeExeption(TrueCryptArgument.MountLetter);
            }
        }


        private bool DriveExist(string DriveLetter){
            try
            {
                System.IO.DriveInfo drvInfo = new System.IO.DriveInfo(DriveLetter);
                return drvInfo.IsReady;
            }
            catch (System.IO.DriveNotFoundException e)
            {
                return false;
            }
        }
    }

    class DriveLetterNotFreeExeption : Exception
    {
        public string DriveLetter;
        public DriveLetterNotFreeExeption(string uDriveLetter)
        {
            DriveLetter = uDriveLetter;
        }
    }
}
