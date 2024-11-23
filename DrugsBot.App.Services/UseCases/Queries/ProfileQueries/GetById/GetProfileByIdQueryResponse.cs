using DrugsBot.App.Services.Dtos.EmailDtos;

namespace DrugsBot.App.Services.UseCases.Queries.ProfileQueries.GetById
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ProfileId"></param>
    /// <param name="ExternalId"></param>
    /// <param name="Email"></param>
    public sealed record class GetProfileByIdQueryResponse(Guid ProfileId, string ExternalId, EmailResponse? Email);
}
