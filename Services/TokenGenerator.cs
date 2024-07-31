using Microsoft.IdentityModel.Tokens;
using PayrollManagerAPI.Models.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace YTCG_Deck_Builder_API.Services
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", user.Id),
                    new Claim("userName", user.UserName),
                    new Claim("email", user.Email),

                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
