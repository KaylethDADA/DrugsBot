namespace DrugsBot.App.Services.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс репозитория для операций записи.
    /// </summary>
    /// <typeparam name="T">Тип сущности, с которой работает репозиторий.</typeparam>
    public interface IWrirteRepository<T> where T : class
    {
        /// <summary>
        /// Репозиторий для операций чтения.
        /// </summary>
        IReadRepository<T> ReadRepository { get; }

        /// <summary>
        /// Добавить новую сущность в хранилище.
        /// </summary>
        /// <param name="entity">Экземпляр сущности для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Асинхронная задача.</returns>
        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить существующую сущность в хранилище.
        /// </summary>
        /// <param name="entity">Экземпляр сущности для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Асинхронная задача.</returns>
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удалить сущность из хранилища по идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Асинхронная задача.</returns>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
