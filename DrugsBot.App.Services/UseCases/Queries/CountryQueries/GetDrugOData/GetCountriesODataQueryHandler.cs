using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories;
using DrugsBot.App.Services.UseCases.Queries.CountryQueries.GetById;
using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.UseCases.Queries.CountryQueries.GetDrugOData
{
    /// <summary>
    /// Обработчик запроса для получения стран с использованием OData.
    /// </summary>
    public sealed class GetCountriesODataQueryHandler : IQueryHandler<GetCountriesODataQuery, GetCountriesODataQueryResponse>
    {
        private readonly IReadRepository<Country> _countryReadRepository;

        public GetCountriesODataQueryHandler(IReadRepository<Country> countryReadRepository)
        {
            _countryReadRepository = countryReadRepository;
        }

        /// <summary>
        /// Обработка запроса.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Ответ с списком стран, соответствующих OData-опциям.</returns>
        public async Task<GetCountriesODataQueryResponse> Handle(GetCountriesODataQuery request, CancellationToken cancellationToken)
        {
            var queryable = await _countryReadRepository.GetQueryableAsync(request.ODataOptions, cancellationToken);

            var countryResponses = queryable.Select(country => new GetCountryByIdQueryResponse(
                country.Id,
                country.Name,
                country.CountryCode
            )).ToList();

            return new GetCountriesODataQueryResponse(countryResponses);
        }
    }
}
