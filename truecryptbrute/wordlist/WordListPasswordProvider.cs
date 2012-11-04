using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using truecryptbrute.Wordlist;

namespace truecryptbrute.WordList
{
    /// <summary>Singleton
    /// 
    /// </summary>
    public sealed class WordListPasswordProvider : IPasswordProvider
    {
        #region singleton

        static readonly WordListPasswordProvider mInstance = new WordListPasswordProvider();

        static WordListPasswordProvider() { }

        WordListPasswordProvider() { }

        public static WordListPasswordProvider Instance
        {
            get { return mInstance; }
        }

        #endregion

        public event EventHandler<PasswordProgressEventArgs> PasswordProgressEvent;

        private StreamReader WordListReader;
        private int mLineReadCount = 0;
        private int mLineCount = 0;
        private object Locker = new object();


        public void LoadWordList(string WordListPath) {
            if(File.Exists(WordListPath)){
                WordListReader = new StreamReader(WordListPath);
                WordlistAnalysis(WordListPath);
            }
        }

        private void WordlistAnalysis(string WordListPath){
            var file = new StreamReader(WordListPath);
            int counter = 0;
            while(file.ReadLine() != null) {
                counter++;
            }
            this.mLineCount = counter;
            file.Close();
        }

        public int PasswordCount {
            get { return mLineCount; }
        }

        public int CurrentPasswordIndex {
            get{ return mLineReadCount; }
        }

        public string NextPassword() {
            lock(Locker) {
                var pass = WordListReader.ReadLine();
                if(pass != null)
                    ++this.mLineReadCount;
                if(PasswordProgressEvent != null)
                    PasswordProgressEvent(this, new PasswordProgressEventArgs(mLineReadCount, mLineCount, pass));
                return pass;
            }
        }
    }
}
