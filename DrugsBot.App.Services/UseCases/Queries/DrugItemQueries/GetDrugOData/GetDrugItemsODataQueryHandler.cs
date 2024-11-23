using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugItemRepositories;
using DrugsBot.App.Services.UseCases.Queries.DrugItemQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.DrugItemQueries.GetDrugOData
{
    /// <summary>
    /// Обработчик запроса для получения списка сущностей типа DrugItem с использованием OData.
    /// </summary>
    public sealed class GetDrugItemsODataQueryHandler : IQueryHandler<GetDrugItemsODataQuery, GetDrugItemsODataQueryResponse>
    {
        private readonly IDrugItemReadRepository _drugItemReadRepository;

        public GetDrugItemsODataQueryHandler(IDrugItemReadRepository drugItemReadRepository)
        {
            _drugItemReadRepository = drugItemReadRepository;
        }

        /// <inheritdoc/>
        public async Task<GetDrugItemsODataQueryResponse> Handle(GetDrugItemsODataQuery request, CancellationToken cancellationToken)
        {
            var queryable = await _drugItemReadRepository.GetQueryableAsync(request.ODataOptions, cancellationToken);

            var items = queryable.Select(drugItem => new GetDrugItemsByIdQueryResponse(
                drugItem.Id,
                drugItem.DrugId,
                drugItem.DrugStoreId,
                drugItem.Cost,
                drugItem.Count
            )).ToList();

            return new GetDrugItemsODataQueryResponse(items);
        }
    }
}
