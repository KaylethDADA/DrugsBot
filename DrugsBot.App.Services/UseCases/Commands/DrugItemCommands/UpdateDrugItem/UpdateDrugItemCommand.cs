using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugItemCommands.UpdateDrugItem;

/// <summary>
/// Команда для обновления сущности типа DrugItem.
/// </summary>
public sealed record UpdateDrugItemCommand(Guid Id, Guid DrugId, Guid DrugStoreId, decimal Cost, double Count)
    : ICommand;