using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace CybersecurityEncryptions.Models
{
	public class VignereCipher : AbstractCipher
	{
		public string EncryptedMessage {
			get
			{
				if(string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Message))
				{
					return string.Empty;
				}
				var sb = new StringBuilder();
				for (int i = 0; i < Message.Length; i++)
				{
					if (Message[i] == ' ')
					{
						sb.Append(' ');
					}
					else 
					{
						var keyIndex = i % Key.Length;
						var keyChar = Key[keyIndex];
						var keyCharIndex = Alphabet.IndexOf(keyChar);
						var messageChar = Message[i];
						var messageCharIndex = Alphabet.IndexOf(messageChar);
						var encryptedCharIndex = (messageCharIndex + keyCharIndex) % Alphabet.Length;
						var encryptedChar = Alphabet[encryptedCharIndex];
						sb.Append(encryptedChar);
					}
				}
				return sb.ToString();
			}
		}
		public string DecryptedMessage { 
			get
			{
				if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Message))
				{
					return string.Empty;
				}
				var sb = new StringBuilder();
				for (int i = 0; i < Message.Length; i++)
				{
					if (EncryptedMessage[i] == ' ')
					{
						sb.Append(' ');
					}
					else
					{
						var keyIndex = i % Key.Length;
						var keyChar = Key[keyIndex];
						var keyCharIndex = Alphabet.IndexOf(keyChar);
						var encryptedChar = Message[i];
						var encryptedCharIndex = Alphabet.IndexOf(encryptedChar);
						var decryptedCharIndex = (encryptedCharIndex - keyCharIndex + Alphabet.Length) % Alphabet.Length;
						var decryptedChar = Alphabet[decryptedCharIndex];
						sb.Append(decryptedChar);
					}
				}
				return sb.ToString();
			}
		}
		public KeyMessageTypeEnum type { get; set; }

	}
}
