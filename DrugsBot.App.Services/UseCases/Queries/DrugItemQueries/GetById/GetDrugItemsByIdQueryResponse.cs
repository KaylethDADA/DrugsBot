namespace DrugsBot.App.Services.UseCases.Queries.DrugItemQueries.GetById
{
    /// <summary>
    /// Ответ на запрос получения DrugItem.
    /// </summary>
    public sealed record GetDrugItemsByIdQueryResponse(
        Guid Id,
        Guid DrugId,
        Guid DrugStoreId,
        decimal Cost,
        double Count);
}
