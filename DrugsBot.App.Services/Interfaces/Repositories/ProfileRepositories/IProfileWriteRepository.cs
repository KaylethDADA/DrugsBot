using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.Interfaces.Repositories.ProfileRepositories
{
    /// <summary>
    /// Репозиторий для операций записи сущностей типа Profile.
    /// </summary>
    public interface IProfileWriteRepository : IWriteRepository<Profile>
    {
    }
}
