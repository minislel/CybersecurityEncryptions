using System.Text;

namespace CybersecurityEncryptions.Models
{
	public class PlayfairCipher : AbstractCipher, ICipher
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
                foreach (var c in key)
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
                foreach (var c in Alphabet)
                {
                    if (!square.Contains(c))
                    {
                        square.Add(c);
                    }
                }
            }
            return square.ToArray();
        }
        public static int[] findPosition(char[] square, char c)
        {
            int[] position = new int[2];
            for (int i = 0; i < square.Length; i++)
            {
                if (square[i] == c)
                {
                    position[0] = i / 5;
                    position[1] = i % 5;
                    break;
                }
            }
            return position;
        }
        public static string DecryptMessage(string message, string key)
        {
            message = NormalizeString(message).Replace('J', 'I');
            if (message.Length % 2 != 0)
            {
                message += 'X';
            }
            char[] square = generateSquare(key);
            StringBuilder sb = new();
            for (int i = 0; i < message.Length; i += 2)
            {
                char a = message[i];
                char b = message[i + 1];
                int[] aPos = findPosition(square, a);
                int[] bPos = findPosition(square, b);
                if (aPos[0] == bPos[0]) // same row
                {
                    int newAcol = (aPos[1] - 1 + 5) % 5;
                    int newBcol = (bPos[1] - 1 + 5) % 5;
                    char newA = square[aPos[0] * 5 + newAcol];
                    char newB = square[bPos[0] * 5 + newBcol];
                    sb.Append(newA);
                    sb.Append(newB);
                }
                else if (aPos[1] == bPos[1]) // same column
                {
                    int newArow = (aPos[0] - 1 + 5) % 5;
                    int newBrow = (bPos[0] - 1 + 5) % 5;
                    char newA = square[newArow * 5 + aPos[1]];
                    char newB = square[newBrow * 5 + bPos[1]];
                    sb.Append(newA);
                    sb.Append(newB);
                }
                else // rectangle case
                {
                    char newA = square[aPos[0] * 5 + bPos[1]];
                    char newB = square[bPos[0] * 5 + aPos[1]];
                    sb.Append(newA);
                    sb.Append(newB);
                }
            }
            return sb.ToString();
        }
        public static string EncryptMessage(string message, string key)
		{
            message = NormalizeString(message).Replace('J', 'I');
            if (message.Length % 2 != 0)
            {
                message += 'X';
            }
            char[] square = generateSquare(key);
            StringBuilder sb = new();
            for (int i = 0; i < message.Length; i+=2)
            { 
                char a = message[i];
                char b = message[i+1];
                int[] aPos = findPosition(square, a);
                int[] bPos = findPosition(square, b);
                if (aPos[0] == bPos[0]) // same row
                {
                    int newAcol = (aPos[1] + 1) % 5;
                    int newBcol = (bPos[1] + 1) % 5;
                    char newA = square[aPos[0] * 5 + newAcol];
                    char newB = square[bPos[0] * 5 + newBcol];
                    sb.Append(newA);
                    sb.Append(newB);
                }
                else if (aPos[1] == bPos[1]) // same column
                {
                    int newArow = (aPos[0] + 1) % 5;
                    int newBrow = (bPos[0] + 1) % 5;
                    char newA = square[newArow * 5 + aPos[1]];
                    char newB = square[newBrow * 5 + bPos[1]];
                    sb.Append(newA);
                    sb.Append(newB);
                }
                else
                {
                    char newA = square[aPos[0] * 5 + bPos[1]];
                    char newB = square[bPos[0] * 5 + aPos[1]];
                    sb.Append(newA);
                    sb.Append(newB);
                }
            }
            return sb.ToString();
        }
	}
}
