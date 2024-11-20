using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.Domain.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace DrugsBot.App.Services.UseCases.Queries.DrugQueries.GetDrugOData
{
    /// <summary>
    /// Запрос для получения списка препаратов с использованием OData-опций.
    /// </summary>
    public sealed record GetDrugsODataQuery(ODataQueryOptions<Drug> ODataOptions) : IQuery<GetDrugsODataQueryResponse>;
}
