using DrugsBot.App.Services.UseCases.Queries.DrugItemQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.DrugItemQueries.GetDrugOData
{
    /// <summary>
    /// Ответ на запрос для получения списка сущностей типа DrugItem.
    /// </summary>
    public sealed record GetDrugItemsODataQueryResponse(ICollection<GetDrugItemsByIdQueryResponse> Items);
}
