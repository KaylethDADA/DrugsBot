using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.Interfaces.Repositories.DrugRepositories
{
    /// <summary>
    /// Интерфейс репозитория для операций записи с сущностью Drug.
    /// </summary>
    public interface IDrugWriteRepository : IWriteRepository<Drug>
    {
    }
}
