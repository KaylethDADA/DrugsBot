using DrugsBot.Domain.Entities;
using DrugsBot.Domain.Primitives;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DrugsBot.Domain.Validators;

/// <summary>
/// Валидатор для сущности <see cref="Drug"/>.
/// </summary>
public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 150).WithMessage(ValidationMessage.LengthField)
            .Matches(DrugNameRegex).WithMessage(ValidationMessage.InvalidFormat);

        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.RequiredField)
            .NotEmpty().WithMessage(ValidationMessage.RequiredField)
            .Length(2, 100).WithMessage(ValidationMessage.LengthField)
            .Matches(ManufacturerRegex).WithMessage(ValidationMessage.InvalidFormat);
    }

    /// <summary>
    /// Регулярное выражение для проверки корректности имени лекарства.
    /// </summary>
    private static Regex DrugNameRegex = new(@"^[A-Za-zА-Яа-яёЁ0-9\s]+$");

    /// <summary>
    /// Регулярное выражение для проверки корректности производителя.
    /// </summary>
    private static Regex ManufacturerRegex = new(@"^[A-Za-zА-Яа-яёЁ\s\.-]+$");
}