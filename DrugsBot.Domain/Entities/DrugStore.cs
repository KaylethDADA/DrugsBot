using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.Validators;
using DrugsBot.Domain.ValueObjects;

namespace DrugsBot.Domain.Entities
{
    /// <summary>
    /// Аптека.
    /// </summary>
    public class DrugStore : BaseEntity<DrugStore>
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

            ValidateEntity(new DrugStoreValidator());
        }

#pragma warning disable CS8618
        public DrugStore() { }
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

        /// <summary>
        /// Навигационное свойство для связи с DrugItem
        /// </summary>
        public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();

        /// <summary>
        /// Обновить основные параметры сущности DrugStore.
        /// </summary>
        /// <param name="drugNetwork">Сеть аптек.</param>
        /// <param name="number">Номер аптеки.</param>
        /// <param name="address">Адрес аптеки.</param>
        /// <returns>Обновленный объект аптеки.</returns>
        public DrugStore Update(string drugNetwork, int number, Address address)
        {
            DrugNetwork = drugNetwork;
            Number = number;
            Address = address;

            ValidateEntity(new DrugStoreValidator());

            return this;
        }
    }
}
