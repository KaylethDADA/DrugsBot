using DrugsBot.App.Services.UseCases.Queries.CountryQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.CountryQueries.GetDrugOData
{
    /// <summary>
    /// Ответ на запрос получения стран с применением OData-опций.
    /// </summary>
    public sealed record class GetCountriesODataQueryResponse(ICollection<GetCountryByIdQueryResponse> Items);
}
