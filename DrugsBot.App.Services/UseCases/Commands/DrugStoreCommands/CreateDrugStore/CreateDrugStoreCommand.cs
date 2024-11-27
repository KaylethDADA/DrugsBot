using DrugsBot.App.Services.Dtos.AddressDtos;
using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugStoreCommands.CreateDrugStore;

/// <summary>
/// Команда для создания аптеки.
/// </summary>
public sealed record CreateDrugStoreCommand(string DrugNetwork, int Number, AddressRequest Address) : ICommand;