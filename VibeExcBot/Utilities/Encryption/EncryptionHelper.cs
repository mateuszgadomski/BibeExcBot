using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace VibeExcBot.Utilities.Encryption
{
    public class EncryptionHelper
    {
        private static readonly byte[] key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); //32
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("1234567890123456"); //16

        public static string GetEnvironmentWithDecrypt(string environmentVariableName)
        {
            var environmentDescripted = Environment.GetEnvironmentVariable(environmentVariableName);

            if (string.IsNullOrEmpty(environmentDescripted))
            {
                var result = MessageBox.Show("Dołącz do serwera Discord, aby uzyskać dostęp do aplikacji. Kliknij OK, aby dołączyć.", "Błąd", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    Process.Start(new ProcessStartInfo("https://discord.gg/UaXQzhDg") { UseShellExecute = true });
                }

                throw new Exception($"Brak zmiennej środowiskowej {environmentVariableName}.");
            }

            if (!IsBase64String(environmentDescripted))
            {
                MessageBox.Show($"Zmienna środowiskowa {environmentVariableName} jest błędna. Uzyskaj poprawne dane i instrukcje do użycia aplikacji na discord: https://discord.gg/UaXQzhDg.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Nieprawidłowy format Base64.");
            }

            try
            {
                using Aes aes = Aes.Create();
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using MemoryStream ms = new(Convert.FromBase64String(environmentDescripted));
                using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
                using StreamReader sr = new(cs);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas deszyfrowania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static bool IsBase64String(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                return false;
            }

            base64 = base64.Trim();
            return (base64.Length % 4 == 0) && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,2}$");
        }
    }
}
