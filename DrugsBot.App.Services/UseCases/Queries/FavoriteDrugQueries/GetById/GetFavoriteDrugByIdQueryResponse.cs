namespace DrugsBot.App.Services.UseCases.Queries.FavoriteDrugQueries.GetById
{
    /// <summary>
    /// Ответ на запрос для получения избранного препарата по идентификатору.
    /// </summary>
    public sealed record GetFavoriteDrugByIdQueryResponse(
        Guid ProfileId,
        Guid DrugId,
        Guid? DrugStoreId
    );
}
