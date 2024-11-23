namespace DrugsBot.App.Services.Dtos.AddressDtos
{
    /// <summary>
    /// DTO для представления ответа адреса.
    /// </summary>
    public sealed record class AddressResponse(string City, string Street, string House, string CountryCode);
}
