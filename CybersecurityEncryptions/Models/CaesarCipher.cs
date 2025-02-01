using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class CaesarCipher : AbstractCipher
    {
		public string DecryptMessage(string message, int key)
        {
            if (message is not null)
            {
                StringBuilder sb = new StringBuilder();
                var mes = message.ToUpper();
                foreach (char c in mes)
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
        public string EncryptMessage(string message, int key)
        {
            if (message is not null)
            {
                StringBuilder sb = new StringBuilder();
                var mes = message.ToUpper();
                foreach (char c in mes)
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
		public override string EncryptMessage(string message, string key)
		{
            return EncryptMessage(message, int.Parse(key));
		}
		public override string DecryptMessage(string message, string key)
		{
			return DecryptMessage(message, int.Parse(key));
		}
	}
}
