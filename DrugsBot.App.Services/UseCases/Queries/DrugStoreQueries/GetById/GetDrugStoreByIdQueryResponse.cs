using DrugsBot.App.Services.Dtos.AddressDtos;

namespace DrugsBot.App.Services.UseCases.Queries.DrugStoreQueries.GetById
{
    public sealed record GetDrugStoreByIdQueryResponse(
        Guid Id,
        string DrugNetwork,
        int Number,
        AddressResponse Address
    );
}
