using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace truecryptbrute.WordList
{
    public delegate void WordListProgressEventHandler(object sender, WordListEventArgs e);


    public class WordListEventArgs : EventArgs
    {
        public int WordListCurrentLine = 0;

        public WordListEventArgs(int uWordListCurrentLine) {
            WordListCurrentLine = uWordListCurrentLine;
        }
    }


    /// <summary>Singleton
    /// 
    /// </summary>
    public class WordListProvider
    {
        static readonly WordListProvider mInstance = new WordListProvider();

        public event WordListProgressEventHandler WordListProgressEvent;

        private StreamReader WordListReader;
        private int mLineReadCount = 0;
        private int mLineCount = 0;

        #region singleton

        static WordListProvider() { }

        WordListProvider() { }

        public static WordListProvider Instance {
            get { return mInstance; }
        }

        #endregion

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
            this.LineCount = counter;
            file.Close();
        }

        public int LineCount {
            get { return mLineCount; }
            set { mLineCount = value; }
        }
        public int CurrentLine {
            get{ return mLineReadCount; }
            set {
                mLineReadCount = value;
                if(WordListProgressEvent != null)
                    WordListProgressEvent(this, new WordListEventArgs(mLineReadCount));
            }
        }

        public string NextPassword() {
            ++this.CurrentLine;
           return WordListReader.ReadLine();
        }
    }
}
