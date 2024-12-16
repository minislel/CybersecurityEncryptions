using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class CaesarCipher
	{
		public string Key { get; set; }
		public string Message { get; set; }
		public string EncryptedMessage
		{
			get
			{
				if (Message is not null)
				{ 
				StringBuilder sb = new StringBuilder();
				var mes = Message.ToUpper();
				foreach (char c in mes)
				{
					if (Alphabet.Contains(c))
					{
						
						int index = Array.IndexOf(Alphabet, c);
						int key = int.Parse(Key);
						int encryptedIndex = (index + key) % 26;
						sb.Append(Alphabet[encryptedIndex]);
					}
				}
				return sb.ToString();
				}
				return string.Empty;
			}
		}
		public string DecryptedMessage
		{
			get
			{
				if(Message is not null)
				{

				
				StringBuilder sb = new StringBuilder();
				var mes = Message.ToUpper();
				foreach (char c in mes)
				{
					if (Alphabet.Contains(c))
					{

						int index = Array.IndexOf(Alphabet, c);
						int key = int.Parse(Key);
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
		}
		public KeyMessageTypeEnum type { get; set; }
		public char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
	}
	public enum KeyMessageTypeEnum
	{
		Encrypt,
		Decrypt
	}
}
