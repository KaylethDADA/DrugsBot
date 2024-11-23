using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugItemRepositories;
using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.UseCases.Commands.DrugItemCommands.CreateDrugItem
{
    /// <summary>
    /// Обработчик команды добавления новой сущности типа DrugItem.
    /// </summary>
    public sealed class CreateDrugItemCommandHandler : ICommandHandler<CreateDrugItemCommand>
    {
        private readonly IDrugItemWriteRepository _drugItemWriteRepository;

        public CreateDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository)
        {
            _drugItemWriteRepository = drugItemWriteRepository;
        }

        /// <summary>
        /// Обработка команды создания новой cвязи между препаратом и аптекой.
        /// </summary>
        /// <param name="request">Команда для создания новой аптеки.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        /// TODO: Добавить валидацию для проверки есть ли в бд такой Id как DrugId и DrugStoreId
        public async Task Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
        {
            var drugItem = new DrugItem(request.DrugId, request.DrugStoreId, request.Cost, request.Count);
            await _drugItemWriteRepository.AddAsync(drugItem, cancellationToken);
        }
    }
}
