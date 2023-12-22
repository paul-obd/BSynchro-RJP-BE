using Azure;
using BS_RJP.BLL;
using Microsoft.IdentityModel.Tokens;
using RJP.BLL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BS_RJP.API.Controllers
{
    public static class AuthTools
    {

        public static string CreateToken(User user, IConfiguration Configuration)
        {
            var TokenKey = Configuration["Jwt:Key"];
            var TokenIssuer = Configuration["Jwt:Issuer"];
            var TokenAudience = Configuration["Jwt:Audience"];

            var claims = new[]
                      {
                             new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                             new Claim(ClaimTypes.Name,user.Username),
                             new Claim(ClaimTypes.Email, user.Email)
                        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1), //1 day
                SigningCredentials = creds,
                Issuer = TokenIssuer,
                Audience = TokenAudience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static void ResolveToken(HttpContext HttpContext, IBLLC _BLC)
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = 0;
            if (userIdClaim != null)
            {
                userId = int.Parse(userIdClaim.Value);
                _BLC._CurrentUserId = userId;
            }
            else
            {
                throw new BLLException("User Unauthorized!");
            }
        }
    }
}
