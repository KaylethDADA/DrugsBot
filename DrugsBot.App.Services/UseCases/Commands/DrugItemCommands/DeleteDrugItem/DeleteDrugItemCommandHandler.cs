using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugItemRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.DrugItemCommands.DeleteDrugItem;

/// <summary>
/// Обработчик команды удаления сущности типа DrugItem.
/// </summary>
public sealed class DeleteDrugItemCommandHandler : ICommandHandler<DeleteDrugItemCommand>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    public DeleteDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
    }

    public async Task Handle(DeleteDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = await _drugItemWriteRepository.ReadRepository.GetByIdAsync(request.Id);

        if (drugItem == null)
            throw new KeyNotFoundException($"DrugItem with ID {request.Id} not found.");

        await _drugItemWriteRepository.DeleteAsync(request.Id, cancellationToken);
    }
}