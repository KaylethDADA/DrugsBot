namespace DrugsBot.App.Services.Dtos.AddressDtos
{
    /// <summary>
    /// DTO для запроса обнавления адреса.
    /// </summary>
    public sealed record UpdateAddressRequest(string City, string Street, string House, string CountryCode);
}
