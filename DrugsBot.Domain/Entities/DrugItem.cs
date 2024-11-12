using DrugsBot.Domain.Validators;
using FluentValidation;

namespace DrugsBot.Domain.Entities
{
    /// <summary>
    /// Связь между препаратом и аптекой
    /// </summary>
    public class DrugItem : BaseEntity
    {
        /// <summary>
        /// Конструктор для инициализации
        /// </summary>
        /// <param name="drugId"></param>
        /// <param name="drugStoreId"></param>
        /// <param name="cost"></param>
        /// <param name="count"></param>
        public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count)
        {
            DrugId = drugId;
            DrugStoreId = drugStoreId;
            Cost = cost;
            Count = count;

            new DrugItemValidator().ValidateAndThrow(this);
        }

#pragma warning disable CS8618
        public DrugItem()
        {
            
        }
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
        public int Count { get; private set; }

        public Drug Drug { get; private set; }
        public DrugStore DrugStore { get; private set; }
    }
}
