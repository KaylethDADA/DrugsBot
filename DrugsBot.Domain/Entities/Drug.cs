using DrugsBot.Domain.Validators;
using FluentValidation;

namespace DrugsBot.Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат
    /// </summary>
    public class Drug : BaseEntity
    {
        /// <summary>
        /// Конструктор для инициализации
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manufacturer"></param>
        /// <param name="countryCodeId"></param>
        /// <param name="country"></param>
        public Drug(string name, string manufacturer, string countryCodeId, Country country)
        {
            Name = name;
            Manufacturer = manufacturer;
            CountryCodeId = countryCodeId;
            Country = country;

            new DrugValidator().ValidateAndThrow(this);
        }

#pragma warning disable CS8618
        public Drug()
        {
        }
#pragma warning disable CS8618

        /// <summary>
        /// Название препарата.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Производитель препарата.
        /// </summary>
        public string Manufacturer { get; private set; }

        /// <summary>
        /// Код страны производителя.
        /// </summary>
        public string CountryCodeId { get; private set; }

        public Country Country { get; private set; }
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    }
}
