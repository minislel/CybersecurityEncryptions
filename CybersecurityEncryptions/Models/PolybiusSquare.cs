﻿using System.Globalization;
using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class PolybiusSquare : AbstractCipher
    {
		public static char[] generateSquare(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				 key = "ABCDE";
			}
			List<char> square = new List<char>();
			while (square.Count < 25)
			{
				foreach(var c in key)
				{
					if (!square.Contains(c))
					{
						if (c == 'J' && !square.Contains('I'))
						{
							square.Add('I');
						}
						else
                        square.Add(c);
                    }
                }
				foreach(var c in Alphabet)
				{
                    if (!square.Contains(c))
					{
                        square.Add(c);
                    }
                }
			}
			return square.ToArray();
		}
		public static new string EncryptMessage(string message, string key)
		{
            key = NormalizeString(key);
            message = NormalizeString(message);
            if (!string.IsNullOrEmpty(message))
			{
				StringBuilder sb = new StringBuilder();
                char[] Square = generateSquare(key);
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
		public static new string DecryptMessage(string message, string key)
		{
            key = NormalizeString(key);
            message = NormalizeString(message);
            if (!string.IsNullOrEmpty(message))
			{
				StringBuilder sb = new StringBuilder();
                char[] Square = generateSquare(key);
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
