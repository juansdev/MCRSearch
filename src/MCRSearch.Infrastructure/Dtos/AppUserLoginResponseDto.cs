namespace MCRSearch.src.MCRSearch.Infrastructure.Dtos
{
    public class AppUserLoginResponseDto
    {
        public required AppUserLoginDataDto User { get; set; }
        public required string Token { get; set; }
    }
}
