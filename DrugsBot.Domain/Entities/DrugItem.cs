using DrugsBot.Domain.DomainEvents;
using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.Validators;

namespace DrugsBot.Domain.Entities
{
    /// <summary>
    /// Связь между препаратом и аптекой
    /// </summary>
    public class DrugItem : BaseEntity<DrugItem>
    {
        /// <summary>
        /// Конструктор для инициализации
        /// </summary>
        /// <param name="drugId"></param>
        /// <param name="drugStoreId"></param>
        /// <param name="cost"></param>
        /// <param name="count"></param>
        public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, double count)
        {
            DrugId = drugId;
            DrugStoreId = drugStoreId;
            Cost = cost;
            Count = count;

            ValidateEntity(new DrugItemValidator());
        }

#pragma warning disable CS8618
        public DrugItem() { }
#pragma warning disable CS8618

        /// <summary>
        /// Идентификатор препарата.
        /// </summary>
        public Guid DrugId { get; private set; }

        /// <summary>
        /// Идентификатор аптеки.
        /// </summary>
        public Guid DrugStoreId { get; private set; }

        /// <summary>
        /// Стоимость препарата в данной аптеке.
        /// </summary>
        public decimal Cost { get; private set; }

        /// <summary>
        /// Количество препарата на складе.
        /// </summary>
        public double Count { get; private set; }

        /// <summary>
        /// Связь с объектом Drug.
        /// </summary>
        public Drug Drug { get; private set; }

        /// <summary>
        /// Связь с объектом DrugStore.
        /// </summary>
        public DrugStore DrugStore { get; private set; }

        /// <summary>
        /// Обновить основные параметры сущности DrugItem.
        /// </summary>
        /// <param name="drugId">Идентификатор препарата.</param>
        /// <param name="drugStoreId">Идентификатор аптеки.</param>
        /// <param name="cost">Стоимость препарата.</param>
        /// <param name="count">Количество препарата.</param>
        /// <returns>Обновлённый объект DrugItem.</returns>
        public DrugItem Update(Guid drugId, Guid drugStoreId, decimal cost, double count)
        {
            DrugId = DrugId;
            DrugStoreId = drugStoreId;
            Cost = cost;
            UpdateCount(count);

            ValidateEntity(new DrugItemValidator());
            return this;
        }

        /// <summary>
        /// Обновить количество препарата на складе.
        /// </summary>
        /// <param name="count">Количество препарата.</param>
        public void UpdateCount(double count)
        {
            Count = count;

            ValidateEntity(new DrugItemValidator());
            AddDomainEvent(new DrugItemUpdatedEvent(this.Id, count));
        }
    }
}
