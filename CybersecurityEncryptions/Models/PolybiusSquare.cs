using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class PolybiusSquare
	{
        private static string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        public string Key { get; set; }
		public string Message { get; set; }
		public char[] Square { get; set; }
		public KeyMessageTypeEnum type { get; set; }
		public string EncryptedMessage
		{
			get
			{
				if (!string.IsNullOrEmpty(Message))
				{
					StringBuilder sb = new StringBuilder();
					var mes = Message.ToUpper();
					Square = generateSquare(Key);

					foreach (char c in mes)
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
		}
		public string DecryptedMessage
		{
			get
			{
				if (!string.IsNullOrEmpty(Message))
				{
					StringBuilder sb = new StringBuilder();
					Square = generateSquare(Key);

					for (int i = 0; i < Message.Length; i += 2)
					{
						if (i + 1 < Message.Length && char.IsDigit(Message[i]) && char.IsDigit(Message[i + 1]))
						{
							int row = Message[i] - '1'; 
							int col = Message[i + 1] - '1'; 
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
		public static char[] generateSquare(string key)
		{
			List<char> square = new List<char>();
			while (square.Count < 25)
			{
				foreach(var c in key)
				{  
					if (!square.Contains(c))
					{
                        square.Add(c);
                    }
                }
				foreach(var c in alphabet)
				{
                    if (!square.Contains(c))
					{
                        square.Add(c);
                    }
                }
			}
			return square.ToArray();
		}
		
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
