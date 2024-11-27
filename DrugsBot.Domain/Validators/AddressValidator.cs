using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DrugsBot.Domain.Validators;

/// <summary>
/// Валидатор для сущности <see cref="Address"/>.
/// </summary>
public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(address => address.City)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 50).WithMessage(ValidationMessage.LengthField)
            .Matches(CityRegex).WithMessage(ValidationMessage.OnlyLettersSpacesAndDashes);

        RuleFor(a => a.Street)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(3, 100).WithMessage(ValidationMessage.LengthField)
            .Matches(StreetRegex).WithMessage(ValidationMessage.OnlyLettersDigitsSpacesAndDashes);

        RuleFor(a => a.House)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(1, 10).WithMessage(ValidationMessage.LengthField)
            .Matches(HouseRegex).WithMessage(ValidationMessage.OnlyLettersDigitsAndDashes);

        RuleFor(address => address.CountryCode)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2).WithMessage(ValidationMessage.ValidCountryCode)
            .Matches(CountryCodeRegex).WithMessage(ValidationMessage.ValidCountryCode);
    }

    /// <summary>
    /// Регулярное выражение для проверки корректности города.
    /// </summary>
    private static Regex CityRegex = new(@"^[a-zA-Z\s]+$");

    /// <summary>
    /// Регулярное выражение для проверки корректности улицы.
    /// </summary>
    private static Regex StreetRegex = new(@"^[a-zA-Z\s]+$");

    /// <summary>
    /// Регулярное выражение для проверки корректности дома.
    /// </summary>
    private static Regex HouseRegex = new(@"^[0-9]+[A-Za-zА-Яа-яЁё\-\/]*$");

    /// <summary>
    /// Регулярное выражение для проверки корректности кода.
    /// </summary>
    private static Regex CountryCodeRegex = new(@"^[A-Z]+$");
}