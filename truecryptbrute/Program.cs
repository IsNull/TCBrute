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
            truecryptbrute TCB = new truecryptbrute();
            TCB.ShowMainGUI();
        }
    }
}
