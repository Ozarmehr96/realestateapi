using System;

namespace Ijora.Domain.Interactions
{
    public static class EnumExtensions
    {
        public static string ToEnumString<TEnum>(this TEnum enumValue) where TEnum : Enum
        {
            return enumValue.ToString();
        }

        public static TEnum? ConvertToEnum<TEnum>(string value) where TEnum : struct
        {
            if (Enum.TryParse(value, true, out TEnum result)) // Преобразуем строку без учёта регистра
            {
                return result;
            }

            return null;
        }
    }
}
