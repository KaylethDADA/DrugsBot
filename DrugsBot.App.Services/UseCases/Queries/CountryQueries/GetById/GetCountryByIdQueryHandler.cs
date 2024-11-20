using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.CountryRepositories;

namespace DrugsBot.App.Services.UseCases.Queries.CountryQueries.GetById
{
    /// <summary>
    /// Обработчик запроса получения страны по идентификатору.
    /// </summary>
    public class GetCountryByIdQueryHandler : IQueryHandler<GetCountryByIdQuery, GetCountryByIdQueryResponse>
    {
        private readonly ICountryReadRepository _countryRepository;

        public GetCountryByIdQueryHandler(ICountryReadRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Обработка запроса получения страны по идентификатору.
        /// </summary>
        /// <param name="request">Запрос на получение страны по идентификатору.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Ответ на запрос с данными о стране.</returns>
        public async Task<GetCountryByIdQueryResponse> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (country == null)
                throw new Exception("Country not found");

            return new GetCountryByIdQueryResponse(country.Id, country.Name, country.CountryCode);
        }
    }
}
