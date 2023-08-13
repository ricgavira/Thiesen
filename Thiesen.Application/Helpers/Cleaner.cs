using System.Text.RegularExpressions;

namespace Thiesen.Domain.Helpers
{
    public static class Cleaner
    {
        static string CleanText(string input)
        {
            string cleaned = Regex.Replace(input, @"[^\w\s]", "");
            cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();
            return cleaned;
        }

        static string OnlyNumber(string input)
        {
            string numberOnly = Regex.Replace(input, @"[^\d]", "");
            return numberOnly;
        }
    }
}
