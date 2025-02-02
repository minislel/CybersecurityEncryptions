using System.Globalization;
using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class PolybiusSquare : AbstractCipher, ICipher
    {
		public static char[] Square = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray();
		public static string EncryptMessage(string message, string key) => EncryptMessage(message);
		public static string DecryptMessage(string message, string key) => DecryptMessage(message);
		public static string EncryptMessage(string message)
		{
			message = NormalizeString(message);
			if (!string.IsNullOrEmpty(message))
			{
				StringBuilder sb = new StringBuilder();
				foreach (char c in message)
				{
					if (Square.Contains(c))
					{
						int index = Array.IndexOf(Square, c);
						int row = index / 5 + 1;
						int col = index % 5 + 1;
						sb.Append(row).Append(col);
					}
				}
				return sb.ToString();
			}
			return string.Empty;
		}
		public static string DecryptMessage(string message)
		{
			message = NormalizeString(message);
			if (!string.IsNullOrEmpty(message))
			{
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < message.Length; i += 2)
				{
					if (i + 1 < message.Length && char.IsDigit(message[i]) && char.IsDigit(message[i + 1]))
					{
						int row = message[i] - '1';
						int col = message[i + 1] - '1';
						int index = row * 5 + col;
						if (index >= 0 && index < Square.Length)
						{
							sb.Append(Square[index]);
						}
					}
				}
				return sb.ToString();
			}
			return string.Empty;
		}
	}
}
