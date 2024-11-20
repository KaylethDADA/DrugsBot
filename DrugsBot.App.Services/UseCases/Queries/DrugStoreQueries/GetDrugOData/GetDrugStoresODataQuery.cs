using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.Domain.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace DrugsBot.App.Services.UseCases.Queries.DrugStoreQueries.GetDrugOData
{
    /// <summary>
    /// Запрос для получения списка аптек с использованием OData-опций.
    /// </summary>
    public sealed record GetDrugStoresODataQuery(ODataQueryOptions<DrugStore> ODataOptions) : IQuery<GetDrugStoresODataQueryResponse>;
}
