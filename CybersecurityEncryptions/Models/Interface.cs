namespace CybersecurityEncryptions.Models
{
    public interface ICipher
    {
        public static abstract string EncryptMessage(string message, string key);
        public static abstract string DecryptMessage(string message, string key);
    }
}
