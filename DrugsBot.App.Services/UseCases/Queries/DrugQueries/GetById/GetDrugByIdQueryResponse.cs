namespace DrugsBot.App.Services.UseCases.Queries.DrugQueries.GetById
{
    /// <summary>
    /// Ответ на запрос получения информации о лекарственном препарате.
    /// </summary>
    public sealed record GetDrugByIdQueryResponse(
        Guid Id,
        string Name,
        string Manufacturer,
        string CountryName
    );
}
