using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.CountryRepositories;
using DrugsBot.App.Services.Interfaces.Repositories.DrugRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.DrugCommands.UpdateDrug
{
    /// <summary>
    /// Обработчик команды обновления информации о лекарстве.
    /// </summary>
    public class UpdateDrugCommandHandler : ICommandHandler<UpdateDrugCommand>
    {
        private readonly IDrugWriteRepository _drugRepository;
        private readonly ICountryReadRepository _countryRepository;

        public UpdateDrugCommandHandler(IDrugWriteRepository drugRepository, ICountryReadRepository countryRepository)
        {
            _drugRepository = drugRepository;
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Обработка команды обновления информации о лекарстве.
        /// </summary>
        /// <param name="request">Команда для обновления информации о лекарстве.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
        {
            var drug = await _drugRepository.ReadRepository.GetByIdAsync(request.Id, cancellationToken);
            var country = await _countryRepository.GetByIdAsync(request.CountryCodeId, cancellationToken);

            if (drug == null)
                throw new KeyNotFoundException($"Drug with ID {request.Id} not found.");
            if (country == null)
                throw new KeyNotFoundException($"Country with code {request.CountryCodeId} not found.");

            drug.Update(request.Name, request.Manufacturer, country.Id);
            await _drugRepository.UpdateAsync(drug, cancellationToken);
        }
    }
}
