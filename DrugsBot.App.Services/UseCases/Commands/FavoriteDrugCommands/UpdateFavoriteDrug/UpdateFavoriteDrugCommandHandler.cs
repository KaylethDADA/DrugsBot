using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugReadRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.FavoriteDrugCommands.UpdateFavoriteDrug;

/// <summary>
/// Обработчик команды для обновления избранного препарата.
/// </summary>
public class UpdateFavoriteDrugCommandHandler : ICommandHandler<UpdateFavoriteDrugCommand>
{
    private readonly IFavoriteDrugWriteRepository _favoriteDrugRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="favoriteDrugRepository"></param>
    public UpdateFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugRepository)
    {
        _favoriteDrugRepository = favoriteDrugRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Handle(UpdateFavoriteDrugCommand command, CancellationToken cancellationToken)
    {
        var favoriteDrug =
            await _favoriteDrugRepository.ReadRepository.GetByIdAsync(command.ProfileId, cancellationToken);

        if (favoriteDrug == null)
            throw new KeyNotFoundException($"FavoriteDrug with ProfileId {command.ProfileId} not found.");

        favoriteDrug.Updat(command.ProfileId, command.DrugId, command.DrugStoreId);
        await _favoriteDrugRepository.UpdateAsync(favoriteDrug, cancellationToken);
    }
}