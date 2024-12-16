using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class PolybiusSquare
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
						if (SquareContains(c))
						{
							int row = 0;
							int col = 0;
							for (int i = 0; i < 5; i++)
							{
								for (int j = 0; j < 5; j++)
								{
									if (Square[i * 5 + j] == c)
									{
										row = i;
										col = j;
									}
								}
							}
							sb.Append(Square[row * 5 + col]);
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
						if (SquareContains(c))
						{
							int row = 0;
							int col = 0;
							for (int i = 0; i < 5; i++)
							{
								for (int j = 0; j < 5; j++)
								{
									if (Square[i*5+j] == c)
									{
										row = i;
										col = j;
									}
								}
							}
							sb.Append(Square[row*5 + col]);
						}
					}
					return sb.ToString();
				}
				return string.Empty;
			}
		}
		public static char[] generateSquare()
		{
			string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
			string square = "";
			Random random = new Random();
			int current = random.Next(0, 25);
			while (square.Length < 26)
			{
				if (!square.Contains(alphabet[current]))
				{
					square += alphabet[current];
				}
				random.Next(0, 25);
			}
			 return square.ToCharArray();
		}
		public char[] Square;
		public bool SquareContains(char c)
		{
			foreach (char ch in Square)
			{
				if (ch == c)
				{
					return true;
				}
			}
			return false;
		}

	}
}
