namespace Ijora.Domain.Interactions
{
    public static class Global
    {
        // <summary>
        /// Название политики для CORS.
        /// </summary>
        public const string HttpCorsPolicyName = "AllowSpecificOrigin";

        /// <summary>
        /// Максимальное количество попыток ввода одноразового пароля.
        /// Когда отправляется смс клиенту, то он может до указанного числа попытатся отправить полученный код.
        /// Если он не отправит правльный код, то придется заново указать номер телефона.
        /// </summary>
        public static short AuthOTPRetryCount = 3;

        /// <summary>
        /// Длина одноразового пароля OTP (sms код подтвержения).
        /// </summary>
        public static int OTPLength = 4;

        /// <summary>
        /// Время действия токена доступа в минутах.
        /// </summary>
        public static double AccessTokenExpieredAtMinutes = 3;

        /// <summary>
        /// Время действия токена обновления в днях.
        /// </summary>
        public static double RefreshTokenExpieredAtDays = 5;
    }
}
