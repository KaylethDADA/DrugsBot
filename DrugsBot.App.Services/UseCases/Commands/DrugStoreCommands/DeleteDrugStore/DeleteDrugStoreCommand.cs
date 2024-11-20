using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugStoreCommands.DeleteDrugStore
{
    /// <summary>
    /// Команда для удаления аптеки.
    /// </summary>
    public sealed record DeleteDrugStoreCommand(Guid Id) : ICommand;
}
