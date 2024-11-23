using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories;
using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.UseCases.Queries.DrugItemQueries.GetById
{
    /// <summary>
    /// Обработчик для получения информации о DrugItem по его идентификатору.
    /// </summary>
    public sealed class GetDrugItemsByIdQueryHandler : IQueryHandler<GetDrugItemsByIdQuery, GetDrugItemsByIdQueryResponse>
    {
        private readonly IReadRepository<DrugItem> _drugItemRepository;

        /// <summary>
        /// Конструктор для инициализации зависимостей.
        /// </summary>
        /// <param name="drugItemRepository">Репозиторий для чтения сущностей DrugItem.</param>
        public GetDrugItemsByIdQueryHandler(IReadRepository<DrugItem> drugItemRepository)
        {
            _drugItemRepository = drugItemRepository;
        }

        /// <summary>
        /// Обработка запроса для получения информации о DrugItem.
        /// </summary>
        /// <param name="request">Запрос с идентификатором DrugItem.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Ответ с данными о DrugItem.</returns>
        public async Task<GetDrugItemsByIdQueryResponse> Handle(GetDrugItemsByIdQuery request, CancellationToken cancellationToken)
        {
            var drugItem = await _drugItemRepository.GetByIdAsync(request.Id, cancellationToken);

            if (drugItem == null)
                throw new KeyNotFoundException($"DrugItem с Id {request.Id} не найден.");

            return new GetDrugItemsByIdQueryResponse(
                drugItem.Id,
                drugItem.DrugId,
                drugItem.DrugStoreId,
                drugItem.Cost,
                drugItem.Count
            );
        }
    }
}
