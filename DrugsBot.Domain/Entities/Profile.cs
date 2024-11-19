using DrugsBot.Domain.Primitives;
using DrugsBot.Domain.Validators;
using DrugsBot.Domain.ValueObjects;

namespace DrugsBot.Domain.Entities
{
    public class Profile : BaseEntity<Profile>
    {
        public Profile(string externalId, Email? email)
        {
            ExternalId = externalId;
            Email = email;

            ValidateEntity(new ProfileValidator());
        }

        /// <summary>
        /// Внешний идентификатор.
        /// </summary>
        public string ExternalId { get; private set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public Email? Email { get; private set; }

        public List<FavoriteDrug> FavoriteDrugs { get; private set; } = [];
    }
}
