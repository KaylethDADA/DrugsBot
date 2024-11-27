using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.Interfaces.Repositories.DrugItemRepositories;

/// <summary>
/// Репозиторий для операций чтения сущностей типа DrugItem.
/// </summary>
public interface IDrugItemReadRepository : IReadRepository<DrugItem>
{
}