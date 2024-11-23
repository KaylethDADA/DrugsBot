using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.Domain.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace DrugsBot.App.Services.UseCases.Queries.FavoriteDrugQueries.GetDrugOData
{
    /// <summary>
    /// Запрос для получения списка избранных препаратов с использованием OData.
    /// </summary>
    public sealed record GetFavoriteDrugODataQuery(ODataQueryOptions<FavoriteDrug> Options) : IQuery<GetFavoriteDrugODataQueryResponse>;
}
