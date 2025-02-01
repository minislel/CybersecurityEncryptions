using System.Globalization;
using System.Text;

namespace CybersecurityEncryptions.Models
{
    public abstract class AbstractCipher
    {
        protected static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string NormalizeString(string value)
        {
            value = value.Replace('ł', 'l').Replace('Ł', 'L');
            var normalizedString = value.Normalize(NormalizationForm.FormKD);
            var stringBuilder = new StringBuilder();
            foreach (var c in normalizedString.EnumerateRunes())
            {
                var unicodeCategory = Rune.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToUpper();
        }
        private string _key;
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = NormalizeString(value);
            }
        }
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = NormalizeString(value);
            }
        }
        public bool IsModelValid()
		{
            return (!string.IsNullOrEmpty(Message) && !string.IsNullOrEmpty(Key));
		}
        public abstract string EncryptMessage(string message, string key);
		public abstract string DecryptMessage(string message, string key);
	}
}
