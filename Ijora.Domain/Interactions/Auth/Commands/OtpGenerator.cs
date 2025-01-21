using System;
using System.Security.Cryptography;

namespace Ijora.Domain.Interactions.Auth.Commands
{
    public class OtpGenerator
    {
        public static string GenerateOtp(int length = 6)
        {
            byte[] randomBytes = new byte[4]; // Для генерации случайного числа
            RandomNumberGenerator.Fill(randomBytes); // Генерация случайных байтов

            // Преобразуем байты в целое число
            int randomNumber = Math.Abs(BitConverter.ToInt32(randomBytes, 0));

            // Генерируем 6-значный код
            int otp = randomNumber % 1000000;
            return otp.ToString("D" + length.ToString()); // Форматируем как шестизначное число
        }
    }
}
