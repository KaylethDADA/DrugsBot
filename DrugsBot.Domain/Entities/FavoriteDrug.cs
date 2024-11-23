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
            Guid? drugStoreId = null)
        {
            ProfileId = profileId;
            DrugId = drugId;
            DrugStoreId = drugStoreId;
        }

#pragma warning disable CS8618
        public FavoriteDrug() { }
#pragma warning disable CS8618

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

        /// <summary>
        /// Обновить основные параметры сущности FavoriteDrug.
        /// </summary>
        /// <param name="profileId">Идентификатор профиля.</param>
        /// <param name="drugId">Идентификатор препарата.</param>
        /// <param name="drugStoreId">Идентификатор аптеки.</param>
        /// <returns></returns>
        public FavoriteDrug Updat(Guid profileId, Guid drugId, Guid? drugStoreId = null)
        {
            ProfileId = profileId;
            DrugId = drugId;
            DrugStoreId = drugStoreId;

            return this;
        }
    }
}
