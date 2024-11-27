using Microsoft.AspNetCore.OData.Query;

namespace DrugsBot.App.Services.Interfaces.Repositories;

/// <summary>
/// Интерфейс репозитория для операций чтения.
/// </summary>
/// <typeparam name="T">Тип сущности, с которой работает репозиторий.</typeparam>
public interface IReadRepository<T> where T : class
{
    /// <summary>
    /// Получить сущность по её уникальному идентификатору.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Экземпляр сущности или null, если она не найдена.</returns>
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить запрос к сущностям с использованием OData-опций.
    /// </summary>
    /// <param name="options">OData-опции для формирования запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Запрос, позволяющий выполнить фильтрацию, сортировку и другие операции.</returns>
    Task<IQueryable<T>> GetQueryableAsync(ODataQueryOptions<T> options, CancellationToken cancellationToken = default);
}