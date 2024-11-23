using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugReadRepositories;

namespace DrugsBot.App.Services.UseCases.Queries.FavoriteDrugQueries.GetById
{
    /// <summary>
    /// Обработчик запроса для получения избранного препарата по идентификатору.
    /// </summary>
    public class GetFavoriteDrugByIdQueryHandler : IQueryHandler<GetFavoriteDrugByIdQuery, GetFavoriteDrugByIdQueryResponse>
    {
        private readonly IFavoriteDrugReadRepository _favoriteDrugReadRepository;

        /// <summary>
        /// Конструктор обработчика запроса для получения избранного препарата.
        /// </summary>
        /// <param name="favoriteDrugReadRepository">Репозиторий для чтения данных о препаратах.</param>
        public GetFavoriteDrugByIdQueryHandler(IFavoriteDrugReadRepository favoriteDrugReadRepository)
        {
            _favoriteDrugReadRepository = favoriteDrugReadRepository;
        }

        /// <summary>
        /// Обрабатывает запрос для получения избранного препарата по его идентификатору.
        /// </summary>
        /// <param name="query">Запрос с идентификатором препарата.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Ответ с данными о выбранном препарате.</returns>
        public async Task<GetFavoriteDrugByIdQueryResponse> Handle(GetFavoriteDrugByIdQuery query, CancellationToken cancellationToken = default)
        {
            var favoriteDrug = await _favoriteDrugReadRepository.GetByIdAsync(query.Id, cancellationToken);

            if (favoriteDrug == null)
                throw new KeyNotFoundException($"Favorite drug with ID {query.Id} not found.");

            return new GetFavoriteDrugByIdQueryResponse(
                favoriteDrug.ProfileId,
                favoriteDrug.DrugId,
                favoriteDrug.DrugStoreId
            );
        }
    }
}
