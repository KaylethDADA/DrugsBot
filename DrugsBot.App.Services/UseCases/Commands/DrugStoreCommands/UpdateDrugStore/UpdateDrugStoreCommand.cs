using DrugsBot.App.Services.Dtos.AddressDtos;
using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.DrugStoreCommands.UpdateDrugStore
{
    /// <summary>
    /// Команда для обновления информации об аптеке.
    /// </summary>
    public sealed record UpdateDrugStoreCommand(Guid Id, string DrugNetwork, int Number, AddressRequest Address) : ICommand;
}
