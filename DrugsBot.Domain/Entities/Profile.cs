using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.Validators;
using DrugsBot.Domain.ValueObjects;

namespace DrugsBot.Domain.Entities;

/// <summary>
/// Представляет профиль пользователя с внешним идентификатором и электронной почтой.
/// </summary>
public class Profile : BaseEntity<Profile>
{
    public Profile(string externalId, Email? email)
    {
        ExternalId = externalId;
        Email = email;

        ValidateEntity(new ProfileValidator());
    }

#pragma warning disable CS8618
    public Profile()
    {
    }
#pragma warning disable CS8618

    /// <summary>
    /// Внешний идентификатор.
    /// </summary>
    public string ExternalId { get; private set; }

    /// <summary>
    /// Электронная почта.
    /// </summary>
    public Email? Email { get; private set; }

    /// <summary>
    /// Навигационное свойство для связи с FavoriteDrug.
    /// </summary>
    public List<FavoriteDrug> FavoriteDrugs { get; private set; } = new List<FavoriteDrug>();

    /// <summary>
    /// Обновить основные параметры сущности Profile.
    /// </summary>
    /// <param name="externalId">Внешний идентификатор.</param>
    /// <param name="email">Электронная почта.</param>
    /// <returns></returns>
    public Profile Update(Guid externalId, Email? email)
    {
        ExternalId = ExternalId;
        Email = email;

        return this;
    }
}