using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace truecryptbrute
{
    

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if(Environment.OSVersion.Platform != PlatformID.Win32NT) {
                MessageBox.Show("This Version uses native 32bit Win dll and wont work on your Operatingsystem. Sorry." + Environment.NewLine + "Application will shutdown...", "Operating System not supportet", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            } else {
                TrueCryptBruter TCB = new TrueCryptBruter();
                TCB.ShowMainGUI();
            }
        }
    }
}
