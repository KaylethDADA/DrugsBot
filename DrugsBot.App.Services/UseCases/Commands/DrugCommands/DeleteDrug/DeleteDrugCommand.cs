using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugCommands.DeleteDrug
{
    /// <summary>
    /// Команда для удаления лекарства по идентификатору.
    /// </summary>
    public sealed record DeleteDrugCommand(Guid Id) : ICommand;
}
