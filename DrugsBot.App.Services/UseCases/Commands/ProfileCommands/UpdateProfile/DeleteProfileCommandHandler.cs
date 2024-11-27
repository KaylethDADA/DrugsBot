using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.ProfileRepositories;
using DrugsBot.App.Services.UseCases.Commands.ProfileCommands.DeleteProfile;

namespace DrugsBot.App.Services.UseCases.Commands.ProfileCommands.UpdateProfile;

/// <summary>
/// Обработчик команды удаления профиля.
/// </summary>
public class DeleteProfileCommandHandler : ICommandHandler<DeleteProfileCommand>
{
    private readonly IProfileWriteRepository _writeRepository;

    /// <summary>
    /// Конструктор обработчика команды удаления профиля.
    /// </summary>
    /// <param name="writeRepository">Репозиторий для записи профилей.</param>
    public DeleteProfileCommandHandler(IProfileWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    /// <summary>
    /// Обработать команду удаления профиля.
    /// </summary>
    /// <param name="command">Команда удаления профиля.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    public async Task Handle(DeleteProfileCommand command, CancellationToken cancellationToken = default)
    {
        var profile = await _writeRepository.ReadRepository.GetByIdAsync(command.ProfileId, cancellationToken);

        if (profile == null)
            throw new KeyNotFoundException($"Профиль с ID {command.ProfileId} не найден.");

        await _writeRepository.DeleteAsync(profile.Id, cancellationToken);
    }
}