using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.DrugRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.DrugCommands.DeleteDrug
{
    /// <summary>
    /// Обработчик команды удаления лекарства.
    /// </summary>
    public class DeleteDrugCommandHandler : ICommandHandler<DeleteDrugCommand>
    {
        private readonly IDrugWriteRepository _drugRepository;

        public DeleteDrugCommandHandler(IDrugWriteRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        /// <summary>
        /// Обработка команды удаления лекарства.
        /// </summary>
        /// <param name="request">Команда для удаления лекарства.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
        {
            var drug = await _drugRepository.ReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (drug == null)
                throw new Exception("Drug not found");

            await _drugRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
