using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.FavoriteDrugCommands.CreateFavoriteDrug
{
    /// <summary>
    /// Команда для создания нового избранного препарата.
    /// </summary>
    public sealed record CreateFavoriteDrugCommand(Guid ProfileId, Guid DrugId, Guid? DrugStoreId = null) : ICommand;

}
