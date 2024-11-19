using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DrugsBot.Domain.Validators
{
    /// <summary>
    /// Валидатор для сущности <see cref="Country"/>.
    /// </summary>
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage(ValidationMessage.NullException(nameof(Country.Name)))
                .NotEmpty().WithMessage(ValidationMessage.EmptyException(nameof(Country.Name)))
                .Length(2, 100).WithMessage(ValidationMessage.InvalidFormat(nameof(Country.Name)))
                .Matches(CountryNameRegex).WithMessage(ValidationMessage.InvalidFormat(nameof(Country.Name)));

            RuleFor(c => c.CountryCode)
                .NotNull().WithMessage(ValidationMessage.NullException(nameof(Country.CountryCode)))
                .NotEmpty().WithMessage(ValidationMessage.EmptyException(nameof(Country.CountryCode)))
                .Length(2).WithMessage(ValidationMessage.InvalidFormat(nameof(Country.CountryCode)))
                .Matches(CountryCodeRegex).WithMessage(ValidationMessage.InvalidFormat(nameof(Country.CountryCode)));
        }

        /// <summary>
        /// Регулярное выражение для проверки корректности кода.
        /// </summary>
        private static Regex CountryCodeRegex = new Regex(@"^[A-Z]+$");

        /// <summary>
        /// Регулярное выражение для проверки корректности имени.
        /// </summary>
        public static Regex CountryNameRegex = new Regex(@"^[A-Za-zА-Яа-яёЁ\s]+$");
    }
}
