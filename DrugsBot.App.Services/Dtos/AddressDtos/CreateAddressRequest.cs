namespace DrugsBot.App.Services.Dtos.AddressDtos
{
    /// <summary>
    /// DTO для запроса создания адреса.
    /// </summary>
    public sealed record CreateAddressRequest(string City, string Street, string House, string CountryCode);
}
