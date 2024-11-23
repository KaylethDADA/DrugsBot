using DrugsBot.App.Services.UseCases.Queries.DrugStoreQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.DrugStoreQueries.GetDrugOData
{
    /// <summary>
    /// Ответ на запрос получения аптек с применением OData-опций.
    /// </summary>
    public sealed record GetDrugStoresODataQueryResponse(ICollection<GetDrugStoreByIdQueryResponse> Items);
}
