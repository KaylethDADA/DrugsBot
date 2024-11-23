using DrugsBot.App.Services.Dtos.EmailDtos;
using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.ProfileRepositories;

namespace DrugsBot.App.Services.UseCases.Queries.ProfileQueries.GetById
{
    /// <summary>
    /// Обработчик запроса получения профиля по ID.
    /// </summary>
    public class GetProfileByIdQueryHandler : IQueryHandler<GetProfileByIdQuery, GetProfileByIdQueryResponse>
    {
        private readonly IProfileReadRepository _readRepository;

        /// <summary>
        /// Конструктор обработчика запроса получения профиля по ID.
        /// </summary>
        /// <param name="readRepository">Репозиторий для чтения профилей.</param>
        public GetProfileByIdQueryHandler(IProfileReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        /// <summary>
        /// Обработать запрос получения профиля по ID.
        /// </summary>
        /// <param name="query">Запрос получения профиля по ID.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<GetProfileByIdQueryResponse> Handle(GetProfileByIdQuery query, CancellationToken cancellationToken = default)
        {
            var profile = await _readRepository.GetByIdAsync(query.Id, cancellationToken);

            if (profile == null)
                throw new KeyNotFoundException($"Профиль с ID {query.Id} не найден.");

            return new GetProfileByIdQueryResponse(
                profile.Id,
                profile.ExternalId,
                profile.Email != null ? new EmailResponse(profile.Email.Value) : null
            );
        }
    }
}
