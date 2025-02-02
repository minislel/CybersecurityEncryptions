using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace CybersecurityEncryptions.Models
{
	public class VignereCipher : AbstractCipher, ICipher
	{
		public static string EncryptMessage(string message, string key)
		{
			key = NormalizeString(key);
            message = NormalizeString(message);
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
			{
				return string.Empty;
			}
			var sb = new StringBuilder();
			for (int i = 0; i < message.Length; i++)
			{
					var keyIndex = i % key.Length;
					var keyChar = key[keyIndex];
					var keyCharIndex = Alphabet.IndexOf(keyChar);
					var messageChar = message[i];
					var messageCharIndex = Alphabet.IndexOf(messageChar);
					var encryptedCharIndex = (messageCharIndex + keyCharIndex) % Alphabet.Length;
					var encryptedChar = Alphabet[encryptedCharIndex];
					sb.Append(encryptedChar);
			}
			return sb.ToString();
		}
		public static string DecryptMessage(string message, string key)
		{
            key = NormalizeString(key);
            message = NormalizeString(message);
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(message))
			{
				return string.Empty;
			}
			var sb = new StringBuilder();
			for (int i = 0; i < message.Length; i++)
			{
					var keyIndex = i % key.Length;
					var keyChar = key[keyIndex];
					var keyCharIndex = Alphabet.IndexOf(keyChar);
					var encryptedChar = message[i];
					var encryptedCharIndex = Alphabet.IndexOf(encryptedChar);
					var decryptedCharIndex = (encryptedCharIndex - keyCharIndex + Alphabet.Length) % Alphabet.Length;
					var decryptedChar = Alphabet[decryptedCharIndex];
					sb.Append(decryptedChar);
				
			}
			return sb.ToString();
		}
	}
}
