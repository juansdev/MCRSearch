using MCRSearch.src.MCRSearch.Application.Dtos;

namespace MCRSearch.src.SharedDtos
{
    public class AppUserLoginResponseDto
    {
        public required AppUserLoginDataDto User { get; set; }
        public required string Token { get; set; }
    }
}
