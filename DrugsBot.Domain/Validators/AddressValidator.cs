using DrugsBot.Domain.Validators.Exceptions;
using DrugsBot.Domain.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DrugsBot.Domain.Validators
{
    /// <summary>
    /// Валидатор для сущности <see cref="Address"/>.
    /// </summary>
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.City)
                .NotNull().WithMessage(ValidationMessages.NullException(nameof(Address.City)))
                .NotEmpty().WithMessage(ValidationMessages.EmptyException(nameof(Address.City)))
                .Length(2, 50).WithMessage(ValidationMessages.InvalidFormat(nameof(Address.City)))
                .Matches(CityRegex).WithMessage(ValidationMessages.InvalidFormat(nameof(Address.City)));

            RuleFor(address => address.Street)
                .NotNull().WithMessage(ValidationMessages.NullException(nameof(Address.Street)))
                .NotEmpty().WithMessage(ValidationMessages.EmptyException(nameof(Address.Street)))
                .Length(3, 100).WithMessage(ValidationMessages.InvalidFormat(nameof(Address.Street)))
                .Matches(StreetRegex).WithMessage(ValidationMessages.InvalidFormat(nameof(Address.Street)));

            RuleFor(address => address.House)
                .NotNull().WithMessage(ValidationMessages.NullException(nameof(Address.House)))
                .NotEmpty().WithMessage(ValidationMessages.EmptyException(nameof(Address.House)))
                .Length(1, 10).WithMessage(ValidationMessages.InvalidFormat(nameof(Address.House)))
                .Matches(HouseRegex).WithMessage(ValidationMessages.InvalidFormat(nameof(Address.House)));

            RuleFor(address => address.CountryCode)
                .NotNull().WithMessage(ValidationMessages.NullException(nameof(Address.CountryCode)))
                .NotEmpty().WithMessage(ValidationMessages.EmptyException(nameof(Address.CountryCode)))
                .Length(2).WithMessage(ValidationMessages.InvalidFormat(nameof(Address.CountryCode)))
                .Matches(CountryCodeRegex).WithMessage(ValidationMessages.InvalidFormat(nameof(Address.CountryCode)));
        }

        /// <summary>
        /// Регулярное выражение для проверки корректности города.
        /// </summary>
        private static Regex CityRegex = new Regex(@"^[a-zA-Z\s]+$");

        /// <summary>
        /// Регулярное выражение для проверки корректности улицы.
        /// </summary>
        private static Regex StreetRegex = new Regex(@"^[a-zA-Z\s]+$");

        /// <summary>
        /// Регулярное выражение для проверки корректности дома.
        /// </summary>
        private static Regex HouseRegex = new Regex(@"^[0-9]+[A-Za-zА-Яа-яЁё\-\/]*$");

        /// <summary>
        /// Регулярное выражение для проверки корректности кода.
        /// </summary>
        private static Regex CountryCodeRegex = new Regex(@"^[A-Z]+$");
    }
}
