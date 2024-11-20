using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugRepositories;

namespace DrugsBot.App.Services.UseCases.Queries.DrugQueries.GetById
{
    /// <summary>
    /// Обработчик запроса получения лекарства по идентификатору.
    /// </summary>
    public class GetDrugByIdQueryHandler : IQueryHandler<GetDrugByIdQuery, GetDrugByIdQueryResponse>
    {
        private readonly IDrugReadRepository _drugRepository;

        public GetDrugByIdQueryHandler(IDrugReadRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        /// <summary>
        /// Обработка запроса получения лекарства по идентификатору.
        /// </summary>
        /// <param name="query">Запрос на получение лекарства по идентификатору.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Ответ на запрос с данными о лекарстве.</returns>
        public async Task<GetDrugByIdQueryResponse> Handle(GetDrugByIdQuery query, CancellationToken cancellationToken)
        {
            var drug = await _drugRepository.GetByIdAsync(query.Id, cancellationToken);
            
            if (drug == null)
                throw new KeyNotFoundException("Drug not found.");

            return new GetDrugByIdQueryResponse(drug.Id, drug.Name, drug.Manufacturer, drug.Country.Name);
        }
    }
}
