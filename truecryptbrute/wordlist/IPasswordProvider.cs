using System;
namespace truecryptbrute.Wordlist
{
    public interface IPasswordProvider
    {
        int CurrentPasswordIndex { get; }
        void LoadWordList(string WordListPath);
        string NextPassword();
        int PasswordCount { get; }
        event EventHandler<PasswordProgressEventArgs> PasswordProgressEvent;
    }
}
