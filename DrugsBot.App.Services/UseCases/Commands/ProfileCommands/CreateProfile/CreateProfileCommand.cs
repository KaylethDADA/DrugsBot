using DrugsBot.App.Services.Dtos.EmailDtos;
using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.ProfileCommands.CreateProfile
{
    /// <summary>
    /// Команда для создания нового профиля.
    /// </summary>
    /// <param name="ExternalId">Внешний идентификатор профиля.</param>
    /// <param name="Email">Электронная почта профиля.</param>
    public sealed record CreateProfileCommand(string ExternalId, EmailRequest? Email) : ICommand;
}
