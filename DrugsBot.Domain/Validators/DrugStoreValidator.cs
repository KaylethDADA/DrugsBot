using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;

namespace DrugsBot.Domain.Validators;

/// <summary>
/// Валидатор для сущности <see cref="DrugStore"/>.
/// </summary>
public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        RuleFor(ds => ds.DrugNetwork)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 100).WithMessage(ValidationMessage.LengthField);

        RuleFor(ds => ds.Number)
            .GreaterThan(0).WithMessage(ValidationMessage.PositiveNumber);

        RuleFor(ds => ds.Address)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .SetValidator(new AddressValidator());
    }
}