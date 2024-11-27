using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugCommands.UpdateDrug;

/// <summary>
/// Команда для обновления информации о лекарстве.
/// </summary>
public sealed record UpdateDrugCommand(Guid Id, string Name, string Manufacturer, Guid CountryCodeId) : ICommand;