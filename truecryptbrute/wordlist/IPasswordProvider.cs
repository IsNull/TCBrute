using System;
namespace truecryptbrute.Wordlist
{
    public interface IPasswordProvider
    {
        int CurrentPasswordIndex { get; }
        void LoadWordList(string WordListPath, int? lineCount);
        string NextPassword();
        int PasswordCount { get; }
        int Progress { get; }
        string LastPassword { get; }
    }
}
