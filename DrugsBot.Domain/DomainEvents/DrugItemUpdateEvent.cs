using DrugsBot.Domain.Primitives;

namespace DrugsBot.Domain.DomainEvents
{
    /// <summary>
    /// Доменное событие обновления единицы лекарства.
    /// </summary>
    public sealed class DrugItemUpdatedEvent : IDomainEvent
    {
        /// <summary>
        /// Идентификатор DrugItem
        /// </summary>
        public Guid DrugItemId { get; }

        /// <summary>
        /// Новое количество
        /// </summary>
        public double NewAmount { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="drugItemId">Идентификатор DrugItem.</param>
        /// <param name="newAmount">Новое кол-во.</param>
        public DrugItemUpdatedEvent(Guid drugItemId, double newAmount)
        {
            DrugItemId = drugItemId;
            NewAmount = newAmount;
        }
    }
}
