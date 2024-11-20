namespace DrugsBot.App.Services.UseCases.Queries.CountryQueries.GetById
{
    /// <summary>
    /// Ответ на запрос получения страны по идентификатору.
    /// </summary>
    public sealed record GetCountryByIdQueryResponse(Guid Id, string Name, string CountryCode);
}
