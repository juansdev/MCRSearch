namespace MCRSearch.src.MCRSearch.Infrastructure.Dtos
{
    public class LoginUserResponseDto
    {
        public required AppUserDataDto User { get; set; }
        public required string Token { get; set; }
    }
}
