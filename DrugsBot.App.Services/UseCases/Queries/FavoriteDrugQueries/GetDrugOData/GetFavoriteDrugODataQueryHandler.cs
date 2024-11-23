using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugReadRepositories;
using DrugsBot.App.Services.UseCases.Queries.FavoriteDrugQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.FavoriteDrugQueries.GetDrugOData
{
    /// <summary>
    /// Обработчик запроса для получения списка избранных препаратов с использованием OData.
    /// </summary>
    public class GetFavoriteDrugODataQueryHandler : IQueryHandler<GetFavoriteDrugODataQuery, GetFavoriteDrugODataQueryResponse>
    {
        private readonly IFavoriteDrugReadRepository _favoriteDrugRepository;

        /// <summary>
        /// Конструктор обработчика запроса для получения списка избранных препаратов.
        /// </summary>
        /// <param name="favoriteDrugRepository">Репозиторий для чтения данных о препаратах.</param>
        public GetFavoriteDrugODataQueryHandler(IFavoriteDrugReadRepository favoriteDrugRepository)
        {
            _favoriteDrugRepository = favoriteDrugRepository;
        }

        /// <summary>
        /// Обрабатывает запрос для получения списка избранных препаратов с использованием OData.
        /// </summary>
        /// <param name="query">Запрос с параметрами OData.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Ответ с данными о списке препаратов.</returns>
        public async Task<GetFavoriteDrugODataQueryResponse> Handle(GetFavoriteDrugODataQuery query, CancellationToken cancellationToken = default)
        {
            var favoriteDrugs = await _favoriteDrugRepository.GetQueryableAsync(query.Options, cancellationToken);

            var items = favoriteDrugs.Select(favorite =>
                new GetFavoriteDrugByIdQueryResponse(favorite.ProfileId, favorite.DrugId, favorite.DrugStoreId ?? null))
                .ToList();

            return new GetFavoriteDrugODataQueryResponse(items);
        }
    }
}
