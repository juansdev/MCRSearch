namespace MCRSearch.src.MCRSearch.Core.Dtos
{
    public class LoginUserResponseDto
    {
        public required RegisterUserDto User { get; set; }
        public required string Token { get; set; }
    }
}
