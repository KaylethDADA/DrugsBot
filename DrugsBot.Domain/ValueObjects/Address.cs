using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.Validators;
using FluentValidation;

namespace DrugsBot.Domain.ValueObjects
{
    /// <summary>
    /// Адрес.
    /// </summary>
    public class Address : BaseValueObject
    {
        /// <summary>
        /// Конструктор для инициализации адреса.
        /// </summary>
        /// <param name="city">Город.</param>
        /// <param name="street">Улица.</param>
        /// <param name="house">Номер дома.</param>
        /// <param name="countryCode">Код страны.</param>
        public Address(string city, string street, string house, string countryCode)
        {
            City = city;
            Street = street;
            House = house;
            CountryCode = countryCode;

            new AddressValidator().ValidateAndThrow(this);
        }

        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Улица.
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Дом.
        /// </summary>
        public string House { get; private set; }

        /// <summary>
        /// Код страны в формате ISO
        /// </summary>
        public string CountryCode { get; private set; }
    }
}
