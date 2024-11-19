namespace DrugsBot.Domain.Primitives
{
    /// <summary>
    /// Сообщения об ошибках валидации.
    /// </summary>
    public class ValidationMessage
    {
        public const string RequiredField = "Поле {PropertyName} является обязательным.";
        public const string LengthField = "Поле {PropertyName} должно содержать от {MinLength} до {MaxLength} символов.";

        /// <summary>
        /// Параметр имеет значение null.
        /// </summary>
        public static readonly Func<string, string> NullException = param => $"{param} is null";

        /// <summary>
        /// Параметр является пустым.
        /// </summary>
        public static readonly Func<string, string> EmptyException = param => $"{param} is empty";

        /// <summary>
        /// Значение параметра меньше ожидаемого.
        /// </summary>
        public static readonly Func<string, string> TooLowValue = param => $"{param} value is too low";

        /// <summary>
        /// Значение параметра больше ожидаемого.
        /// </summary>
        public static readonly Func<string, string> TooHighValue = param => $"{param} value is too high";

        /// <summary>
        /// Дата параметра слишком старая.
        /// </summary>
        public static readonly Func<string, string> OldDateException = param => $"{param} Date is too old";

        /// <summary>
        /// Дата параметра является будущей.
        /// </summary>
        public static readonly Func<string, string> FutureDateException = param => $"{param} Date is future";

        /// <summary>
        /// Формат параметра некорректен.
        /// </summary>
        public static readonly Func<string, string> InvalidFormat = param => $"{param} is invalid format";
    }
}
