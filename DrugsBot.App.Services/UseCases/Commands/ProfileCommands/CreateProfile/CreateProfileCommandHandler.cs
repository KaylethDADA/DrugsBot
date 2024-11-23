using DrugsBot.App.Services.Interfaces.CommandComponents;
using DrugsBot.App.Services.Interfaces.Repositories.ProfileRepositories;
using DrugsBot.Domain.Entities;
using DrugsBot.Domain.ValueObjects;

namespace DrugsBot.App.Services.UseCases.Commands.ProfileCommands.CreateProfile
{
    /// <summary>
    /// Обработчик команды создания профиля.
    /// </summary>
    public class CreateProfileCommandHandler : ICommandHandler<CreateProfileCommand>
    {
        private readonly IProfileWriteRepository _writeRepository;

        /// <summary>
        /// Конструктор обработчика команды создания профиля.
        /// </summary>
        /// <param name="writeRepository">Репозиторий для записи профилей.</param>
        public CreateProfileCommandHandler(IProfileWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        /// <summary>
        /// Обработать команду создания профиля.
        /// </summary>
        /// <param name="request">Команда создания профиля.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        public async Task Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email != null ? new Email(request.Email.Address) : null;

            var profile = new Profile(request.ExternalId, email);

            await _writeRepository.AddAsync(profile, cancellationToken);
        }
    }
}
