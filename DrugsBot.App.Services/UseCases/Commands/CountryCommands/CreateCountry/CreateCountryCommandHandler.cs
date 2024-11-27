using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.CountryRepositories;
using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.UseCases.Commands.CountryCommands.CreateCountry;

/// <summary>
/// Обработчик команды создания новой страны.
/// </summary>
public class CreateCountryCommandHandler : ICommandHandler<CreateCountryCommand>
{
    private readonly ICountryWrirteRepository _countryRepository;

    public CreateCountryCommandHandler(ICountryWrirteRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    /// <summary>
    /// Обработка команды создания новой страны.
    /// </summary>
    /// <param name="request">Команда для создания новой страны.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    public async Task Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country(request.Name, request.CountryCode);

        await _countryRepository.AddAsync(country, cancellationToken);
    }
}