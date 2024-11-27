using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugItemRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.DrugItemCommands.UpdateDrugItem;

/// <summary>
/// Обработчик команды обновления сущности типа DrugItem>.
/// </summary>
public sealed class UpdateDrugItemCommandHandler : ICommandHandler<UpdateDrugItemCommand>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    public UpdateDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Handle(UpdateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = await _drugItemWriteRepository.ReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (drugItem == null)
            throw new KeyNotFoundException($"DrugItem with ID {request.Id} not found.");

        drugItem.Update(request.DrugId, request.DrugStoreId, request.Cost, request.Count);

        await _drugItemWriteRepository.UpdateAsync(drugItem, cancellationToken);
    }
}