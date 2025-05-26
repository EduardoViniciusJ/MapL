using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MapL.Services.Interface
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration configuration);
        string GenerateRefreshToken();
        ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token, IConfiguration configuration);
    }
}
