using System.Text.RegularExpressions;
using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.ValueObjects;
using FluentValidation;

namespace DrugsBot.Domain.Validators;

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(d => d.Value)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 255).WithMessage(ValidationMessage.LengthField)
            .Matches(EmailRegexPattern)
            .WithMessage(ValidationMessage.InvalidEmailMessage);
    }

    /// <summary>
    /// Регулярка для валидации почты
    /// </summary>
    private static readonly Regex EmailRegexPattern = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
}