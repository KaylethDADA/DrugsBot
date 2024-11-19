using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;

namespace DrugsBot.Domain.Validators
{
    /// <summary>
    /// Валидатор для сущности <see cref="DrugStore"/>.
    /// </summary>
    public class DrugStoreValidator : AbstractValidator<DrugStore>
    {
        public DrugStoreValidator()
        {
            RuleFor(ds => ds.DrugNetwork)
                .NotNull().WithMessage(ValidationMessage.NullException(nameof(DrugStore.DrugNetwork)))
                .NotEmpty().WithMessage(ValidationMessage.EmptyException(nameof(DrugStore.DrugNetwork)))
                .Length(2, 100).WithMessage(ValidationMessage.InvalidFormat(nameof(DrugStore.DrugNetwork)));

            RuleFor(ds => ds.Number)
                .GreaterThan(0).WithMessage(ValidationMessage.TooLowValue(nameof(DrugStore.Number)));

            RuleFor(ds => ds.Address)
                .NotNull().WithMessage(ValidationMessage.NullException(nameof(DrugStore.Address)))
                .NotEmpty().WithMessage(ValidationMessage.EmptyException(nameof(DrugStore.Address)))
                .SetValidator(new AddressValidator());
        }
    }
}
