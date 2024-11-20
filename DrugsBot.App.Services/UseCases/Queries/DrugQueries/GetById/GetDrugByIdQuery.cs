using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Queries.DrugQueries.GetById
{
    /// <summary>
    /// Запрос для получения лекарства по идентификатору.
    /// </summary>
    public sealed record GetDrugByIdQuery(Guid Id) : IQuery<GetDrugByIdQueryResponse>;
}
