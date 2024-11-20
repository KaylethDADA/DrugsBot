using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Queries.CountryQueries.GetById
{
    /// <summary>
    /// Запрос для получения страны по идентификатору.
    /// </summary>
    public sealed record GetCountryByIdQuery(Guid Id) : IQuery<GetCountryByIdQueryResponse>;
}
