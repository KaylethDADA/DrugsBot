using MediatR;

namespace DrugsBot.App.Services.Interfaces.CommandComponents
{
    /// <summary>
    /// Базовый интерфейс для команды, которая не возвращает результат
    /// </summary>
    public interface ICommand : IRequest
    {

    }

    /// <summary>
    /// Интерфейс для команды, которая возвращает результат.
    /// </summary>
    /// <typeparam name="TResponce">Тип результата, который возвращает команда.</typeparam>
    public interface ICommand<TResponce> : IRequest<TResponce>
    {

    }
}
