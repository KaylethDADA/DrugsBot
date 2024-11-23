using DrugsBot.App.Services.UseCases.Queries.ProfileQueries.GetById;

namespace DrugsBot.App.Services.UseCases.Queries.ProfileQueries.GetDrugOData
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Items"></param>
    public sealed record GetProfileODataQueryResponse(ICollection<GetProfileByIdQueryResponse> Items);
}
