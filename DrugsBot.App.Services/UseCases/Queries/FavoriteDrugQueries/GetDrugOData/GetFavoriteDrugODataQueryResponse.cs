using DrugsBot.App.Services.UseCases.Queries.FavoriteDrugQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.FavoriteDrugQueries.GetDrugOData
{
    /// <summary>
    /// Ответ на запрос для получения списка избранных препаратов в формате OData.
    /// </summary>
    public sealed record GetFavoriteDrugODataQueryResponse(ICollection<GetFavoriteDrugByIdQueryResponse> Items);
}
