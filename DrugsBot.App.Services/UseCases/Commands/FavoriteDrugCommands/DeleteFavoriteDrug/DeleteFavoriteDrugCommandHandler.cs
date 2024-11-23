using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugReadRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.FavoriteDrugCommands.DeleteFavoriteDrug
{
    /// <summary>
    /// Обработчик команды для удаления избранного препарата.
    /// </summary>
    public class DeleteFavoriteDrugCommandHandler : ICommandHandler<DeleteFavoriteDrugCommand>
    {
        private readonly IFavoriteDrugWriteRepository _favoriteDrugRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="favoriteDrugRepository"></param>
        public DeleteFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugRepository)
        {
            _favoriteDrugRepository = favoriteDrugRepository;
        }

        /// <summary>
        /// Обрабатывает команду для удаления избранного препарата.
        /// </summary>
        /// <param name="command">Команда для удаления избранного препарата.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task Handle(DeleteFavoriteDrugCommand command, CancellationToken cancellationToken)
        {
            var favoriteDrug = await _favoriteDrugRepository.ReadRepository.GetByIdAsync(command.Id, cancellationToken);

            if (favoriteDrug == null)
                throw new KeyNotFoundException($"FavoriteDrug with ID {command.Id} not found.");

            await _favoriteDrugRepository.DeleteAsync(command.Id, cancellationToken);
        }
    }
}
