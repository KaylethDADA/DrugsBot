using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.CountryCommands.CreateCountry
{
    /// <summary>
    /// Команда для создания новой страны.
    /// </summary>
    public sealed record CreateCountryCommand(string Name, string CountryCode) : ICommand;
}
