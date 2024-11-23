using DrugsBot.App.Services.Dtos.EmailDtos;
using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.ProfileRepositories;
using DrugsBot.App.Services.UseCases.Queries.ProfileQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.ProfileQueries.GetDrugOData
{
    /// <summary>
    /// Обработчик запроса получения профилей через OData.
    /// </summary>
    public class GetProfileODataQueryHandler : IQueryHandler<GetProfileODataQuery, GetProfileODataQueryResponse>
    {
        private readonly IProfileReadRepository _readRepository;

        /// <summary>
        /// Конструктор обработчика запроса получения профилей через OData.
        /// </summary>
        /// <param name="readRepository">Репозиторий для чтения профилей.</param>
        public GetProfileODataQueryHandler(IProfileReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        /// <summary>
        /// Обработать запрос получения профилей через OData.
        /// </summary>
        /// <param name="query">Запрос получения профилей через OData.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<GetProfileODataQueryResponse> Handle(GetProfileODataQuery query, CancellationToken cancellationToken = default)
        {
            var profiles = await _readRepository.GetQueryableAsync(query.Options, cancellationToken);

            var items = profiles.Select(profile => new GetProfileByIdQueryResponse(
                profile.Id,
                profile.ExternalId,
                profile.Email != null ? new EmailResponse(profile.Email.Value) : null
            )).ToList();

            return new GetProfileODataQueryResponse(items);
        }
    }
}
