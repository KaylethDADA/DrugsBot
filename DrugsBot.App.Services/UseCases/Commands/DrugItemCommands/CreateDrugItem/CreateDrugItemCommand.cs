using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugItemCommands.CreateDrugItem
{
    /// <summary>
    /// Команда для добавления новой сущности типа DrugItem.
    /// </summary>
    public sealed record CreateDrugItemCommand(Guid DrugId, Guid DrugStoreId, decimal Cost, double Count) : ICommand;
}
