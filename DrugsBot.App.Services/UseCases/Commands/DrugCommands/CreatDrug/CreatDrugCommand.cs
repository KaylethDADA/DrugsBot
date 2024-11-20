using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugCommands.CreatDrug
{
    /// <summary>
    /// Команда для создания нового лекарства.
    /// </summary>
    public sealed record CreatDrugCommand(string Name, string Manufacturer, Guid CountryCodeId) : ICommand;
}
