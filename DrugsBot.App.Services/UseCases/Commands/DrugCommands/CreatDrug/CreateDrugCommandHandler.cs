using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.CountryRepositories;
using DrugsBot.App.Services.Interfaces.Repositories.DrugRepositories;
using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.UseCases.Commands.DrugCommands.CreatDrug;

/// <summary>
/// Обработчик команды создания нового лекарства.
/// </summary>
public class CreateDrugCommandHandler : ICommandHandler<CreatDrugCommand>
{
    private readonly IDrugWriteRepository _drugRepository;
    private readonly ICountryReadRepository _countryRepository;

    public CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository, ICountryReadRepository countryRepository)
    {
        _drugRepository = drugWriteRepository;
        _countryRepository = countryRepository;
    }

    /// <summary>
    /// Обработка команды создания нового лекарства.
    /// </summary>
    /// <param name="request">Команда для создания нового лекарства.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    public async Task Handle(CreatDrugCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetByIdAsync(request.CountryCodeId, cancellationToken);

        if (country == null)
            throw new ArgumentException("Указанная страна не найдена.");

        var drug = new Drug(request.Name, request.Manufacturer, country.Id);

        await _drugRepository.AddAsync(drug, cancellationToken);
    }
}