using DrugsBot.Domain.Entities;

namespace DrugsBot.App.Services.Interfaces.Repositories.DrugReadRepositories;

/// <summary>
/// Интерфейс репозитория для операций записи с сущностью FavoriteDrug.
/// </summary>
public interface IFavoriteDrugWriteRepository : IWriteRepository<FavoriteDrug>
{
}