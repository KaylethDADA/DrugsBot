using MediatR;

namespace DrugsBot.App.Services.Interfaces.CommandComponents
{
    /// <summary>
    /// Интерфейс для запроса, который возвращает результат.
    /// </summary>
    /// <typeparam name="TResponce">Тип возвращаемого результата запроса.</typeparam>
    public interface IQuery<TResponce> : IRequest<TResponce>
    {
    }
}
