using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.ProfileRepositories;
using DrugsBot.App.Services.UseCases.Commands.ProfileCommands.UpdateProfile;
using DrugsBot.Domain.ValueObjects;

namespace DrugsBot.App.Services.UseCases.Commands.ProfileCommands.DeleteProfile
{
    /// <summary>
    /// Обработчик команды обновления профиля.
    /// </summary>
    public class UpdateProfileCommandHandler : ICommandHandler<UpdateProfileCommand>
    {
        private readonly IProfileWriteRepository _writeRepository;

        /// <summary>
        /// Конструктор обработчика команды обновления профиля.
        /// </summary>
        /// <param name="writeRepository">Репозиторий для записи профилей.</param>
        public UpdateProfileCommandHandler(IProfileWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        /// <summary>
        /// Обработать команду обновления профиля.
        /// </summary>
        /// <param name="request">Команда обновления профиля.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken = default)
        {
            var profile = await _writeRepository.ReadRepository.GetByIdAsync(request.ProfileId, cancellationToken);

            if (profile == null)
                throw new KeyNotFoundException($"Профиль с ID {request.ProfileId} не найден.");

            var email = request.Email != null ? new Email(request.Email.Address) : null;

            profile.Update(request.ExternalId, email);

            await _writeRepository.UpdateAsync(profile, cancellationToken);
        }
    }
}
