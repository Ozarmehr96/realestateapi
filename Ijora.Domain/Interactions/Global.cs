namespace Ijora.Domain.Interactions
{
    public static class Global
    {
        /// <summary>
        /// Максимальное количество попыток ввода одноразового пароля.
        /// Когда отправляется смс клиенту, то он может до указанного числа попытатся отправить полученный код.
        /// Если он не отправит правльный код, то придется заново указать номер телефона.
        /// </summary>
        public static short AuthOTPRetryCount = 3;
    }
}
