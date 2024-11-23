using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.Interfaces.Repositories.DrugItemRepositories
{
    /// <summary>
    /// Репозиторий для операций записи сущностей типа DrugItem.
    /// </summary>
    public interface IDrugItemWriteRepository : IWriteRepository<DrugItem>
    {
    }
}