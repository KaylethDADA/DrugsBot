using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;

namespace DrugsBot.Domain.Validators;

/// <summary>
/// Валидатор для сущности <see cref="DrugItem"/>.
/// </summary>
public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(di => di.Cost)
            .GreaterThan(0).WithMessage(ValidationMessage.PositiveNumber)
            .PrecisionScale(10, 2, true).WithMessage(ValidationMessage.InvalidFormat);

        RuleFor(di => di.Count)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.PositiveNumber)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.LengthField);
    }
}