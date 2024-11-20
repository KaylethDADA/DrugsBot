using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.CountryRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.CountryCommands.UpdateCountry
{
    /// <summary>
    /// Обработчик команды обновления информации о стране.
    /// </summary>
    public class UpdateCountryCommandHandler : ICommandHandler<UpdateCountryCommand>
    {
        private readonly ICountryWrirteRepository _countryRepository;

        public UpdateCountryCommandHandler(ICountryWrirteRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Обработка команды обновления информации о стране.
        /// </summary>
        /// <param name="request">Команда для обновления информации о стране.</param>
        /// <param name="cancellationToken">Токен для отмены операции.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.ReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (country == null)
                throw new Exception("Country not found");

            country.Update(request.Name, request.CountryCode);
            await _countryRepository.UpdateAsync(country, cancellationToken);
        }
    }
}
