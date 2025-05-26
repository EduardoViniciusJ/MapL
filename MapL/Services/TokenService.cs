using MapL.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MapL.Services
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration configuration)
        {
            // Pega a chave secreta e converte ela para bytes, depois e instancia as crendencias de assinatura no método SigningCredentials com um algoritmo de assinatura digital. 
            var key = configuration.GetSection("JWT").GetValue<string>("SecretKey") ?? throw new InvalidOperationException("Invalid secret key");
            var privateKey = Encoding.UTF8.GetBytes(key);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256);

            // Descrição do token
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(configuration.GetSection("JWT").GetValue<double>("TokenValidityInMinutes")),
                Audience = configuration.GetSection("JWT").GetValue<string>("ValidAudience"),
                Issuer = configuration.GetSection("JWT").GetValue<string>("ValidIssuer"),
                SigningCredentials = signingCredentials,
            };

            // Cria o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenCreate = tokenHandler.CreateJwtSecurityToken(tokenDescription);
            return tokenCreate;
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
