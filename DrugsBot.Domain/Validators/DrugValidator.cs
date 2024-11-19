using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DrugsBot.Domain.Validators
{
    /// <summary>
    /// Валидатор для сущности <see cref="Drug"/>.
    /// </summary>
    public class DrugValidator : AbstractValidator<Drug>
    {
        public DrugValidator()
        {
            RuleFor(d => d.Name)
                .NotNull().WithMessage(ValidationMessage.NullException(nameof(Drug.Name)))
                .NotEmpty().WithMessage(ValidationMessage.EmptyException(nameof(Drug.Name)))
                .Length(2, 150).WithMessage(ValidationMessage.InvalidFormat(nameof(Drug.Name)))
                .Matches(DrugNameRegex).WithMessage(ValidationMessage.InvalidFormat(nameof(Drug.Name)));

            RuleFor(d => d.Manufacturer)
                .NotNull().WithMessage(ValidationMessage.NullException(nameof(Drug.Manufacturer)))
                .NotEmpty().WithMessage(ValidationMessage.EmptyException(nameof(Drug.Manufacturer)))
                .Length(2, 100).WithMessage(ValidationMessage.InvalidFormat(nameof(Drug.Manufacturer)))
                .Matches(ManufacturerRegex).WithMessage(ValidationMessage.InvalidFormat(nameof(Drug.Name)));

            RuleFor(d => d.CountryCodeId)
                .NotNull().WithMessage(ValidationMessage.NullException(nameof(Drug.CountryCodeId)))
                .NotEmpty().WithMessage(ValidationMessage.EmptyException(nameof(Drug.CountryCodeId)))
                .Length(2).WithMessage(ValidationMessage.InvalidFormat(nameof(Drug.CountryCodeId)))
                .Matches(CountryCodeIdRegex).WithMessage(ValidationMessage.InvalidFormat(nameof(Drug.CountryCodeId)));
        }

        /// <summary>
        /// Регулярное выражение для проверки корректности имени лекарства.
        /// </summary>
        public static Regex DrugNameRegex = new Regex(@"^[A-Za-zА-Яа-яёЁ0-9\s]+$");

        /// <summary>
        /// Регулярное выражение для проверки корректности производителя.
        /// </summary>
        public static Regex ManufacturerRegex = new Regex(@"^[A-Za-zА-Яа-яёЁ\s\.-]+$");

        /// <summary>
        /// Регулярное выражение для проверки корректности кода страны.
        /// </summary>
        public static Regex CountryCodeIdRegex = new Regex(@"^[A-Za-z]+$");
    }
}
