using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.Validators;

namespace DrugsBot.Domain.Entities
{
    /// <summary>
    /// Лекарственный препарат.
    /// </summary>
    public class Drug : BaseEntity<Drug>
    {
        /// <summary>
        /// Конструктор для инициализации
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manufacturer"></param>
        /// <param name="countryCodeId"></param>
        /// <param name="country"></param>
        public Drug(string name, string manufacturer, Guid countryCodeId)
        {
            Name = name;
            Manufacturer = manufacturer;
            CountryCodeId = countryCodeId;

            ValidateEntity(new DrugValidator());
        }

#pragma warning disable CS8618
        public Drug() { }
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
        public Guid CountryCodeId { get; private set; }

        /// <summary>
        /// Связь с объектом Country.
        /// </summary>
        public Country Country { get; private set; }

        /// <summary>
        /// Навигационное свойство для связи с DrugItem.
        /// </summary>
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();

        public Drug Update(string name, string manufacturer, Guid countryCodeId)
        {
            Name = name;
            Manufacturer = manufacturer;
            CountryCodeId = countryCodeId;

            ValidateEntity(new DrugValidator());
        
            return this;
        }
    }
}
