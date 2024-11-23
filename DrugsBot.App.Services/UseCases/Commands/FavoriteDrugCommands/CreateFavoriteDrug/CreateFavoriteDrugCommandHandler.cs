using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugReadRepositories;
using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.UseCases.Commands.FavoriteDrugCommands.CreateFavoriteDrug
{
    /// <summary>
    /// Обработчик команды для создания нового избранного препарата.
    /// </summary>
    public class CreateFavoriteDrugCommandHandler : ICommandHandler<CreateFavoriteDrugCommand>
    {
        private readonly IFavoriteDrugWriteRepository _favoriteDrugRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="favoriteDrugRepository"></param>
        public CreateFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugRepository)
        {
            _favoriteDrugRepository = favoriteDrugRepository;
        }

        /// <summary>
        /// Обрабатывает команду для создания нового избранного препарата.
        /// </summary>
        /// <param name="command">Команда для создания нового избранного препарата.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task Handle(CreateFavoriteDrugCommand command, CancellationToken cancellationToken)
        {
            var favoriteDrug = new FavoriteDrug(command.ProfileId, command.DrugId, command.DrugStoreId);

            await _favoriteDrugRepository.AddAsync(favoriteDrug, cancellationToken);
        }
    }
}
