using DrugsBot.Domain.Validators;
using FluentValidation;

namespace DrugsBot.Domain.Entities
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class Country : BaseEntity
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

            new CountryValidator().ValidateAndThrow(this);
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

        public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
    }
}
