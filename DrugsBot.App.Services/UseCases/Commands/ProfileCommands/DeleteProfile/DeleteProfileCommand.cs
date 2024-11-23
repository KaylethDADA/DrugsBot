using DrugsBot.App.Services.Interfaces.CommandComponents;

namespace DrugsBot.App.Services.UseCases.Commands.ProfileCommands.DeleteProfile
{
    /// <summary>
    /// Команда для удаления профиля по его идентификатору.
    /// </summary>
    /// <param name="ProfileId">Идентификатор профиля.</param>
    public sealed record DeleteProfileCommand(Guid ProfileId) : ICommand;
}
