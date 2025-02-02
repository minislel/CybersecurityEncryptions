using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Globalization;
using System.Text;

namespace CybersecurityEncryptions.Models
{
    public abstract class AbstractCipher 
    {
        protected static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string NormalizeString(string value)
        {
            value = value.Replace('ł', 'l').Replace('Ł', 'L').Replace(" ", string.Empty);
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
    }
}
