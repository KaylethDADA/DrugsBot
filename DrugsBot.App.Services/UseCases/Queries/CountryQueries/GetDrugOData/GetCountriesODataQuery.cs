using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.Domain.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace DrugsBot.App.Services.UseCases.Queries.CountryQueries.GetDrugOData
{
    /// <summary>
    /// Запрос для получения списка стран с использованием OData-опций.
    /// </summary>
    public sealed record GetCountriesODataQuery(ODataQueryOptions<Country> ODataOptions) : IQuery<GetCountriesODataQueryResponse>;
}
