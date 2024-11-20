using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugStoreRepositories;
using DrugsBot.Domain.Entities;
using DrugsBot.Domain.ValueObjects;

namespace DrugsBot.App.Services.UseCases.Commands.DrugStoreCommands.CreateDrugStore
{
    /// <summary>
    /// Обработчик команды создания аптеки.
    /// </summary>
    public class CreateDrugStoreCommandHandler : ICommandHandler<CreateDrugStoreCommand>
    {
        private readonly IDrugStoreWriteRepository _drugStoreRepository;

        public CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreRepository)
        {
            _drugStoreRepository = drugStoreRepository;
        }

        /// <summary>
        /// Обработка команды создания новой аптеки.
        /// </summary>
        /// <param name="request">Команда для создания новой аптеки.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Address.City, request.Address.Street, request.Address.House, request.Address.CountryCode);

            var drugStore = new DrugStore(request.DrugNetwork, request.Number, address);
            
            await _drugStoreRepository.AddAsync(drugStore, cancellationToken);
        }
    }
}
