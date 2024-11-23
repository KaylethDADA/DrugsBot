using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.Domain.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace DrugsBot.App.Services.UseCases.Queries.ProfileQueries.GetDrugOData
{
    /// <summary>
    /// Запрос для получения профилей с поддержкой OData.
    /// </summary>
    /// <param name="Options">OData-опции для формирования запроса.</param>
    public sealed record GetProfileODataQuery(ODataQueryOptions<Profile> Options) : IQuery<GetProfileODataQueryResponse>;
}
