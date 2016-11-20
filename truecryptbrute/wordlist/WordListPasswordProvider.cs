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

        private StreamReader WordListReader;
        private int mLineReadCount = 0;
        private int mLineCount = 0;
        private int mStartingLine = 1;
        private string mLastPassword;
        private object Locker = new object();

        /// <summary>
        /// Load wordlist file.
        /// </summary>
        /// <param name="WordListPath">Path to wordlist file.</param>
        /// <param name="lineCount">Optional line count (if known ahead of time, saves time on analysis).</param>
        public void LoadWordList(string WordListPath, int? lineCount)
        {
            if (File.Exists(WordListPath))
            {
                WordListReader = new StreamReader(WordListPath);
                if (lineCount != null)
                {
                    this.mLineCount = (int)lineCount;
                }
                else
                {
                    WordlistAnalysis(WordListPath);
                }

                // Reset state
                this.mLineReadCount = 0;
                this.mLastPassword = null;
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

        /// <summary>
        /// Line to start reading from in the wordfile.
        /// </summary>
        public int StartingLine
        {
            get
            {
                return this.mStartingLine;
            }
            set
            {
                this.mStartingLine = value;
            }
        }

        /// <summary>
        /// Wordfile progress percent.
        /// </summary>
        public int Progress
        {
            get
            {
                if (this.mLineCount > 0)
                {
                    return Math.Min(this.mLineReadCount / (this.mLineCount / 100), 100);
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Get the password read from the last call of NextPassword()
        /// </summary>
        public string LastPassword
        {
            get
            {
                return mLastPassword;
            }
        }

        /// <summary>
        /// Read the next password from the wordfile.
        /// </summary>
        /// <returns>Password</returns>
        public string NextPassword()
        {
            string pass;

            lock (Locker)
            {
                do
                {
                    pass = WordListReader.ReadLine();
                    if (pass != null)
                    {
                        ++this.mLineReadCount;
                    }
                } while (this.mLineReadCount < this.mStartingLine);

                this.mLastPassword = pass;

                return pass;
            }
        }
    }
}
