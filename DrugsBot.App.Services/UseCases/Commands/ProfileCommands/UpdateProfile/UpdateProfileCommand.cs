using DrugsBot.App.Services.Dtos.EmailDtos;
using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.ProfileCommands.UpdateProfile
{
    /// <summary>
    /// Команда для обновления существующего профиля.
    /// </summary>
    /// <param name="ProfileId">Идентификатор профиля.</param>
    /// <param name="ExternalId">Внешний идентификатор профиля.</param>
    /// <param name="Email">Электронная почта профиля.</param>
    public sealed record UpdateProfileCommand(Guid ProfileId, Guid ExternalId, EmailRequest? Email) : ICommand;
}
