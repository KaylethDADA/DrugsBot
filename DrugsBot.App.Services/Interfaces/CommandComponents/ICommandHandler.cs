using MediatR;

namespace DrugsBot.App.Services.Interfaces.CommandComponents;

/// <summary>
/// Интерфейс обработчика команды, который обрабатывает команды, не возвращающие результат.
/// </summary>
/// <typeparam name="TCommand">Тип команды, которую обрабатывает обработчик.</typeparam>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

/// <summary>
/// Интерфейс для команды, которая возвращает результат.
/// </summary>
/// <typeparam name="TResponce">Тип возвращаемого результата команды.</typeparam>
public interface ICommandHandler<TCommand, TResponce> : IRequestHandler<TCommand, TResponce>
    where TCommand : ICommand<TResponce>
{
}