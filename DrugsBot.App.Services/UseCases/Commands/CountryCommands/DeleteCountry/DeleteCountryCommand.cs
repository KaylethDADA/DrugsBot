using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.CountryCommands.DeleteCountry;

/// <summary>
/// Команда для удаления страны по идентификатору.
/// </summary>
public sealed record DeleteCountryCommand(Guid Id) : ICommand;