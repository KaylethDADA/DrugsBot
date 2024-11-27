using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.Interfaces.Repositories.DrugRepositories;

/// <summary>
/// Интерфейс репозитория для операций чтения с сущностью Drug.
/// </summary>
public interface IDrugReadRepository : IReadRepository<Drug>
{
}