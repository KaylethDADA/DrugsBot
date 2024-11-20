using DrugsBot.App.Services.Dtos.AddressDtos;
using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugStoreRepositories;
using DrugsBot.App.Services.UseCases.Queries.DrugStoreQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.DrugStoreQueries.GetDrugOData
{
    /// <summary>
    /// Обработчик запроса для получения списка аптек с использованием OData.
    /// </summary>
    public sealed class GetDrugStoresODataQueryHandler : IQueryHandler<GetDrugStoresODataQuery, GetDrugStoresODataQueryResponse>
    {
        private readonly IDrugStoreReadRepository _drugStoreRepository;

        public GetDrugStoresODataQueryHandler(IDrugStoreReadRepository drugStoreRepository)
        {
            _drugStoreRepository = drugStoreRepository;
        }

        /// <summary>
        /// Обработка запроса получения списка аптек с использованием OData.
        /// </summary>
        /// <param name="query">OData-запрос.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task<GetDrugStoresODataQueryResponse> Handle(GetDrugStoresODataQuery query, CancellationToken cancellationToken)
        {
            var queryable = await _drugStoreRepository.GetQueryableAsync(query.ODataOptions, cancellationToken);

            var drugStoreDtos = queryable.Select(drugStore => new GetDrugStoreByIdQueryResponse(
                drugStore.Id,
                drugStore.DrugNetwork,
                drugStore.Number,
                new AddressResponse(
                    drugStore.Address.City,
                    drugStore.Address.Street,
                    drugStore.Address.House,
                    drugStore.Address.CountryCode
                )
            )).ToList();

            return new GetDrugStoresODataQueryResponse(drugStoreDtos);
        }
    }
}
