using DrugsBot.Domain.Validators;
using DrugsBot.Domain.ValueObjects;
using FluentValidation;

namespace DrugsBot.Domain.Entities
{
    /// <summary>
    /// Аптека.
    /// </summary>
    public class DrugStore : BaseEntity    
    {
        /// <summary>
        /// Конструктор для инициализации
        /// </summary>
        /// <param name="drugNetwork"></param>
        /// <param name="number"></param>
        /// <param name="address"></param>
        public DrugStore(string drugNetwork, int number, Address address)
        {
            DrugNetwork = drugNetwork;
            Number = number;
            Address = address;

            new DrugStoreValidator().ValidateAndThrow(this);
        }

#pragma warning disable CS8618
        public DrugStore()
        {
            
        }
#pragma warning disable CS8618

        /// <summary>
        /// Сеть аптек, к которой принадлежит аптека.
        /// </summary>
        public string DrugNetwork { get; private set; }

        /// <summary>
        /// Номер аптеки в сети.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Адрес аптеки.
        /// </summary>
        public Address Address { get; private set; }

        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    }
}
