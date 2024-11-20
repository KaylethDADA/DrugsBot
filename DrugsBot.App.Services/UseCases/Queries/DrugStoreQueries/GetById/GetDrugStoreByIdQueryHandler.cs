using DrugsBot.App.Services.Dtos.AddressDtos;
using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugStoreRepositories;

namespace DrugsBot.App.Services.UseCases.Queries.DrugStoreQueries.GetById
{
    /// <summary>
    /// Обработчик запроса получения аптеки по идентификатору.
    /// </summary>
    public class GetDrugStoreByIdQueryHandler : IQueryHandler<GetDrugStoreByIdQuery, GetDrugStoreByIdQueryResponse>
    {
        private readonly IDrugStoreReadRepository _drugStoreRepository;

        public GetDrugStoreByIdQueryHandler(IDrugStoreReadRepository drugStoreRepository)
        {
            _drugStoreRepository = drugStoreRepository;
        }

        /// <summary>
        /// Обработка запроса получения аптеки по идентификатору.
        /// </summary>
        /// <param name="query">Запрос на получение аптеки по идентификатору.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Ответ с данными об аптеке.</returns>
        public async Task<GetDrugStoreByIdQueryResponse> Handle(GetDrugStoreByIdQuery query, CancellationToken cancellationToken)
        {
            var drugStore = await _drugStoreRepository.GetByIdAsync(query.Id, cancellationToken);

            if (drugStore == null)
                throw new KeyNotFoundException("DrugStore not found.");

            return new GetDrugStoreByIdQueryResponse(
                drugStore.Id,
                drugStore.DrugNetwork,
                drugStore.Number,
                new AddressResponse(
                    drugStore.Address.City,
                    drugStore.Address.Street,
                    drugStore.Address.House,
                    drugStore.Address.CountryCode
                )
            );
        }
    }
}
