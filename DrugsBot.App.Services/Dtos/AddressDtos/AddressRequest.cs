namespace DrugsBot.App.Services.Dtos.AddressDtos;

/// <summary>
/// DTO для запроса создания/обновления адреса.
/// </summary>
public sealed record AddressRequest(string City, string Street, string House, string CountryCode);