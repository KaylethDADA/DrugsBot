using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.Domain.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace DrugsBot.App.Services.UseCases.Queries.DrugItemQueries.GetDrugOData
{
    /// <summary>
    /// Запрос для получения списка сущностей типа DrugItem с использованием OData.
    /// </summary>
    public sealed record GetDrugItemsODataQuery(ODataQueryOptions<DrugItem> ODataOptions) : IQuery<GetDrugItemsODataQueryResponse>;
}
