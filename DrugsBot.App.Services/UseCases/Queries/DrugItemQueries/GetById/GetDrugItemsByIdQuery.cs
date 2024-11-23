using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Queries.DrugItemQueries.GetById
{
    /// <summary>
    /// Запрос для получения информации о связке препарата и аптеки по идентификатору.
    /// </summary>
    /// <param name="Id">Идентификатор DrugItem.</param>
    public sealed record class GetDrugItemsByIdQuery(Guid Id) : IQuery<GetDrugItemsByIdQueryResponse>;
}
