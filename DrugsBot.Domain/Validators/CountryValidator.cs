using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DrugsBot.Domain.Validators;

/// <summary>
/// Валидатор для сущности <see cref="Country"/>.
/// </summary>
public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 100).WithMessage(ValidationMessage.LengthField)
            .Matches(CountryNameRegex).WithMessage(ValidationMessage.InvalidFormat);

        RuleFor(c => c.CountryCode)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2).WithMessage(ValidationMessage.LengthField)
            .Matches(CountryCodeRegex).WithMessage(ValidationMessage.InvalidFormat);
    }

    /// <summary>
    /// Регулярное выражение для проверки корректности кода.
    /// </summary>
    private static Regex CountryCodeRegex = new(@"^[A-Z]+$");

    /// <summary>
    /// Регулярное выражение для проверки корректности имени.
    /// </summary>
    private static Regex CountryNameRegex = new(@"^[A-Za-zА-Яа-яёЁ\s]+$");
}