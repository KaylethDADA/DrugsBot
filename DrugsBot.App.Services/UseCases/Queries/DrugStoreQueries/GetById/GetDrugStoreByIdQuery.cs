using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Queries.DrugStoreQueries.GetById
{
    /// <summary>
    /// Запрос для получения аптеки по идентификатору.
    /// </summary>
    public sealed record GetDrugStoreByIdQuery(Guid Id) : IQuery<GetDrugStoreByIdQueryResponse>;
}
