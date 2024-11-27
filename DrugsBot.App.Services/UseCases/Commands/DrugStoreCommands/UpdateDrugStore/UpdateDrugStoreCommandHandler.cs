using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugStoreRepositories;
using DrugsBot.Domain.ValueObjects;

namespace DrugsBot.App.Services.UseCases.Commands.DrugStoreCommands.UpdateDrugStore;

/// <summary>
/// Обработчик команды обновления аптеки.
/// </summary>
public class UpdateDrugStoreCommandHandler : ICommandHandler<UpdateDrugStoreCommand>
{
    private readonly IDrugStoreWriteRepository _drugStoreRepository;

    public UpdateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreRepository)
    {
        _drugStoreRepository = drugStoreRepository;
    }

    /// <summary>
    /// Обработка команды обновления аптеки.
    /// </summary>
    /// <param name="request">Команда для обновления аптеки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    public async Task Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreRepository.ReadRepository.GetByIdAsync(request.Id, cancellationToken);
        var address = new Address(request.Address.City, request.Address.Street, request.Address.House,
            request.Address.CountryCode);

        if (drugStore == null)
            throw new KeyNotFoundException($"DrugStore with ID {request.Id} not found.");

        drugStore.Update(request.DrugNetwork, request.Number, address);

        await _drugStoreRepository.UpdateAsync(drugStore, cancellationToken);
    }
}