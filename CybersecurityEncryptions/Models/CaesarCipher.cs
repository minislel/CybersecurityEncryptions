using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class CaesarCipher : AbstractCipher, ICipher
    {
		public static string DecryptMessage(string message, int key)
        {
            message = NormalizeString(message);
            if (message is not null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in message)
                {
                    if (Alphabet.Contains(c))
                    {
                        int index = Alphabet.IndexOf(c);
                        int encryptedIndex = (index - key) % 26;
                        if (encryptedIndex < 0)
                        {
                            encryptedIndex += 26;
                        }
                        sb.Append(Alphabet[encryptedIndex]);
                    }
                }
                return sb.ToString();
            }
            return string.Empty;
        }
        public static string EncryptMessage(string message, int key)
        {
            message = NormalizeString(message);
            if (message is not null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in message)
                {
                    if (Alphabet.Contains(c))
                    {
                        int index = Alphabet.IndexOf(c);
                        int encryptedIndex = (index + key) % 26;
                        sb.Append(Alphabet[encryptedIndex]);
                    }
                }
                return sb.ToString();
            }
            return string.Empty;
        }
		public static new string EncryptMessage(string message, string key)
		{
            return EncryptMessage(message, int.Parse(key));
		}
		public static new string DecryptMessage(string message, string key)
		{
			return DecryptMessage(message, int.Parse(key));
		}
	}
}
