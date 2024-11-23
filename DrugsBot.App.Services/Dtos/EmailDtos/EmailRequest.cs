namespace DrugsBot.App.Services.Dtos.EmailDtos
{
    /// <summary>
    /// DTO для создания/обновления электронной почты.
    /// </summary>
    public sealed record EmailRequest(string Address);
}
