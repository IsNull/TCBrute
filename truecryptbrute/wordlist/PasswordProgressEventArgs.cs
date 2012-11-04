using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace truecryptbrute.Wordlist
{

    public class PasswordProgressEventArgs : EventArgs
    {
        public int WordListCurrentLine = 0;
        public int WordListLineCount = 0;
        public string WordListCurrentPass = "";

        public PasswordProgressEventArgs(int uWordListCurrentLine, int uWordListLineCount, string uPass)
        {
            WordListCurrentLine = uWordListCurrentLine;
            WordListLineCount = uWordListLineCount;
            WordListCurrentPass = uPass;
        }
    }

}
