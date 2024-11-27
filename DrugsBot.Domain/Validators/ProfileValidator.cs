using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;

namespace DrugsBot.Domain.Validators;

public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(d => d.ExternalId)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 100).WithMessage(ValidationMessage.LengthField);
    }
}