using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;

namespace DrugsBot.Domain.Validators
{
    /// <summary>
    /// Валидатор для сущности <see cref="DrugItem"/>.
    /// </summary>
    public class DrugItemValidator : AbstractValidator<DrugItem>
    {
        public DrugItemValidator()
        {
            RuleFor(di => di.Cost)
                .GreaterThan(0).WithMessage(ValidationMessage.TooLowValue(nameof(DrugItem.Cost)))
                .PrecisionScale(10, 2, true).WithMessage(ValidationMessage.InvalidFormat(nameof(DrugItem.Cost)));

            RuleFor(di => di.Count)
               .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.TooLowValue(nameof(DrugItem.Count)))
               .LessThanOrEqualTo(10000);
        }
    }
}
