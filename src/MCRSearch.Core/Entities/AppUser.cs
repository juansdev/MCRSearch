using Microsoft.AspNetCore.Identity;

namespace MCRSearch.src.MCRSearch.Core.Entities
{
    public class AppUser: IdentityUser
    {
        public required string Name { get; set; }
    }
}
