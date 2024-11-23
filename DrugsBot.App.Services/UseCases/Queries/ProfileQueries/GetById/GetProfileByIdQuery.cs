using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Queries.ProfileQueries.GetById
{
    /// <summary>
    /// Запрос для получения профиля по его идентификатору.
    /// </summary>
    /// <param name="Id">Идентификатор профиля.</param>
    public sealed record GetProfileByIdQuery(Guid Id) : IQuery<GetProfileByIdQueryResponse>;
}
