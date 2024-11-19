using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.ValueObjects;
using FluentValidation;

namespace DrugsBot.Domain.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            // Валидация для Cost (стоимость)
            RuleFor(d => d.Value)
                .NotEmpty().WithMessage(ValidationMessage.RequiredField)
                .Length(2, 255).WithMessage(ValidationMessage.LengthField)
                .Matches(RegexPatterns.EmailRegexPattern).WithMessage("Значение {PropertyName} не является электронной почтой.");
        }
    }
}
