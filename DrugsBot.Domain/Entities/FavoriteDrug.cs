namespace DrugsBot.Domain.Entities
{
    /// <summary>
    /// Избранный препарат.
    /// </summary>
    public class FavoriteDrug
    {
        public FavoriteDrug(
            Guid profileId,
            Guid drugId,
            Profile profile,
            Drug drug,
            Guid? drugStoreId = null,
            DrugStore? drugStore = null)
        {
            ProfileId = profileId;
            DrugId = drugId;
            DrugStoreId = drugStoreId;
            Profile = profile;
            Drug = drug;
            DrugStore = drugStore;
        }

        /// <summary>
        /// Идентификатор профиля.
        /// </summary>
        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        /// <summary>
        /// Идентификатор препарата.
        /// </summary>
        public Guid DrugId { get; private set; }
        public Drug Drug { get; private set; }

        /// <summary>
        /// Идентификатор аптеки.
        /// </summary>
        public Guid? DrugStoreId { get; private set; }
        public DrugStore? DrugStore { get; private set; }
    }
}
