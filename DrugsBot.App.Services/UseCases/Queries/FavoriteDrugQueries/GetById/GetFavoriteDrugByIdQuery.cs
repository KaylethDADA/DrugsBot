using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Queries.FavoriteDrugQueries.GetById
{
    /// <summary>
    /// Запрос для получения избранного препарата по идентификатору.
    /// </summary>
    public sealed record GetFavoriteDrugByIdQuery(Guid Id) : IQuery<GetFavoriteDrugByIdQueryResponse>;
}
