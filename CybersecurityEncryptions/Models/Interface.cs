namespace CybersecurityEncryptions.Models
{
    public interface ICipher
    {
        static abstract string EncryptMessage(string message, string key);
        static abstract string DecryptMessage(string message, string key);
    }
}
