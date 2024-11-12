using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Validators.Exceptions;
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
                .NotNull().WithMessage(ValidationMessages.NullException(nameof(DrugStore.DrugNetwork)))
                .NotEmpty().WithMessage(ValidationMessages.EmptyException(nameof(DrugStore.DrugNetwork)))
                .Length(2, 100).WithMessage(ValidationMessages.InvalidFormat(nameof(DrugStore.DrugNetwork)));

            RuleFor(ds => ds.Number)
                .GreaterThan(0).WithMessage(ValidationMessages.TooLowValue(nameof(DrugStore.Number)));

            RuleFor(ds => ds.Address)
                .NotNull().WithMessage(ValidationMessages.NullException(nameof(DrugStore.Address)))
                .NotEmpty().WithMessage(ValidationMessages.EmptyException(nameof(DrugStore.Address)))
                .SetValidator(new AddressValidator());
        }
    }
}
