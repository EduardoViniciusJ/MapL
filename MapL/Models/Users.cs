using Microsoft.AspNetCore.Identity;

namespace MapL.Models
{
    public class Users : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
