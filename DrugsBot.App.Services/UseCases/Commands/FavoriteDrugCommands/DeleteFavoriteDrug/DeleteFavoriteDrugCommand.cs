using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.FavoriteDrugCommands.DeleteFavoriteDrug;

/// <summary>
/// Команда для удаления избранного препарата.
/// </summary>
public sealed record DeleteFavoriteDrugCommand(Guid Id) : ICommand;