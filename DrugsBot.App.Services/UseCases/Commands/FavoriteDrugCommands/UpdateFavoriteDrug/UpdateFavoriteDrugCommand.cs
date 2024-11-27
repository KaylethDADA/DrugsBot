using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.FavoriteDrugCommands.UpdateFavoriteDrug;

/// <summary>
/// Команда для обновления избранного препарата.
/// </summary>
public sealed record UpdateFavoriteDrugCommand(Guid ProfileId, Guid DrugId, Guid? DrugStoreId = null) : ICommand;