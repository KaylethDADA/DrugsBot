using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.CountryRepositories;

namespace DrugsBot.App.Services.UseCases.Commands.CountryCommands.DeleteCountry;

/// <summary>
/// Обработчик команды удаления страны.
/// </summary>
public class DeleteCountryCommandHandler : ICommandHandler<DeleteCountryCommand>
{
    private readonly ICountryWrirteRepository _countryRepository;

    public DeleteCountryCommandHandler(ICountryWrirteRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    /// <summary>
    /// Обработка команды удаления страны.
    /// </summary>
    /// <param name="request">Команда для удаления страны.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.ReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (country == null)
            throw new Exception("Country not found");

        await _countryRepository.DeleteAsync(request.Id, cancellationToken);
    }
}