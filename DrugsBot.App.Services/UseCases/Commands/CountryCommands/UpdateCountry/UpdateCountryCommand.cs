using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.CountryCommands.UpdateCountry;

/// <summary>
/// Команда для обновления информации о стране.
/// </summary>
public sealed record UpdateCountryCommand(Guid Id, string Name, string CountryCode) : ICommand;