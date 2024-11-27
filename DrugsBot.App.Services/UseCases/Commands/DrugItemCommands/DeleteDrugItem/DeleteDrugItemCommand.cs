using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugItemCommands.DeleteDrugItem;

/// <summary>
/// Команда для удаления сущности типа DrugItem.
/// </summary>
public sealed record DeleteDrugItemCommand(Guid Id) : ICommand;