using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.Validators;

namespace DrugsBot.Domain.Entities;

/// <summary>
/// Справочник стран.
/// </summary>
public class Country : BaseEntity<Country>
{
    /// <summary>
    /// Конструктор для инициализации страны с названием и кодом.
    /// </summary>
    /// <param name="name">Название страны.</param>
    /// <param name="code">Код страны.</param>
    public Country(string name, string code)
    {
        Name = name;
        CountryCode = code;

        ValidateEntity(new CountryValidator());
    }

#pragma warning disable CS8618
    public Country()
    {
    }
#pragma warning disable CS8618


    /// <summary>
    /// Название страны.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Код страны (например, ISO-код).
    /// </summary>
    public string CountryCode { get; private set; }

    /// <summary>
    /// Навигационное свойство для связи с препаратами.
    /// </summary>
    public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();

    /// <summary>
    /// Обновить основные параметры сущности Country.
    /// </summary>
    /// <param name="name">Название страны.</param>
    /// <param name="code">Код страны.</param>
    /// <returns>Обновленный объект Country.</returns>
    public Country Update(string name, string code)
    {
        Name = name;
        CountryCode = code;

        ValidateEntity(new CountryValidator());

        return this;
    }
}