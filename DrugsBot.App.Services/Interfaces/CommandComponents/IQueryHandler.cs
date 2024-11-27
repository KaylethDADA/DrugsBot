using MediatR;

namespace DrugsBot.App.Services.Interfaces.CommandComponents;

/// <summary>
/// Интерфейс обработчика запроса, который обрабатывает запросы и возвращает результат.
/// </summary>
/// <typeparam name="TQuery">Тип запроса, который обрабатывает обработчик.</typeparam>
/// <typeparam name="TResponce">Тип результата, который возвращает обработчик.</typeparam>
public interface IQueryHandler<TQuery, TResponce> : IRequestHandler<TQuery, TResponce>
    where TQuery : IQuery<TResponce>
{
}