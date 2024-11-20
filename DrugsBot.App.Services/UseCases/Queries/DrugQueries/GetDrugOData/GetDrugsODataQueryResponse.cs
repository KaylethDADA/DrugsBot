using DrugsBot.App.Services.UseCases.Queries.DrugQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.DrugQueries.GetDrugOData
{
    /// <summary>
    /// Ответ на запрос получения препаратов с применением OData-опций.
    /// </summary>
    public sealed record class GetDrugsODataQueryResponse(ICollection<GetDrugByIdQueryResponse> Responses);
}
