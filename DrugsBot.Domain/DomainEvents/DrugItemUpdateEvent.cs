using DrugsBot.Domain.Interfaces;
using DrugsBot.Domain.Primitives;

namespace DrugsBot.Domain.DomainEvents;

/// <summary>
/// Доменное событие обновления единицы лекарства.
/// </summary>
public sealed record DrugItemUpdatedEvent(Guid DrugItemId, double NewAmount) : IDomainEvent;