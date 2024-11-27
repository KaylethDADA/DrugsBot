using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugStoreRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.DrugStoreCommands.DeleteDrugStore;

/// <summary>
/// Обработчик команды удаления аптеки.
/// </summary>
public class DeleteDrugStoreCommandHandler : ICommandHandler<DeleteDrugStoreCommand>
{
    private readonly IDrugStoreWriteRepository _drugStoreRepository;

    public DeleteDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreRepository)
    {
        _drugStoreRepository = drugStoreRepository;
    }

    /// <summary>
    /// Обработка команды удаления аптеки.
    /// </summary>
    /// <param name="request">Команда для удаления аптеки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    public async Task Handle(DeleteDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreRepository.ReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (drugStore == null)
            throw new KeyNotFoundException($"DrugStore with ID {request.Id} not found.");

        await _drugStoreRepository.DeleteAsync(request.Id, cancellationToken);
    }
}