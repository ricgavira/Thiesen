using Thiesen.Domain.Helpers;

namespace Thiesen.Application.Helpers
{
    public static class CPFHelper
    {
        public static string FormatCPF(string cpf)
        {
            cpf = StringHelper.OnlyNumber(cpf);
            return string.Format("{0:000\\.000\\.000\\-00}", long.Parse(cpf));
        }

        public static bool IsValid(string cpf)
        {
            cpf = StringHelper.OnlyNumber(cpf);

            if (cpf.Length != 11) return false;

            if (cpf.Distinct().Count() == 1) return false;
                        
            int[] factors = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * factors[i];
            }

            int remainder = sum % 11;
            int firstDigit = (remainder < 2) ? 0 : 11 - remainder;

            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * factors[i + 1];
            }

            sum += firstDigit * factors[0];

            remainder = sum % 11;

            int secondDigit = (remainder < 2) ? 0 : 11 - remainder;

            return cpf.EndsWith($"{firstDigit}{secondDigit}");
        }
    }
}