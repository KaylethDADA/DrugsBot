using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugRepositories;
using DrugsBot.App.Services.UseCases.Queries.DrugQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.DrugQueries.GetDrugOData
{
    /// <summary>
    /// Обработчик запроса для получения препаратов с использованием OData.
    /// </summary>
    public sealed class GetDrugsODataQueryHandler : IQueryHandler<GetDrugsODataQuery, GetDrugsODataQueryResponse>
    {
        private readonly IDrugReadRepository _drugReadRepository;

        public GetDrugsODataQueryHandler(IDrugReadRepository drugReadRepository)
        {
            _drugReadRepository = drugReadRepository;
        }

        /// <summary>
        /// Обработка запроса.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Запрос препаратов с примененными OData-опциями.</returns>
        public async Task<GetDrugsODataQueryResponse> Handle(GetDrugsODataQuery request, CancellationToken cancellationToken)
        {
            var queryable = await _drugReadRepository.GetQueryableAsync(request.ODataOptions, cancellationToken);

            var drugResponses = queryable.Select(drug => new GetDrugByIdQueryResponse(
                drug.Id,
                drug.Name,
                drug.Manufacturer,
                drug.Country.Name
            )).ToList();

            return new GetDrugsODataQueryResponse(drugResponses);
        }
    }
}
