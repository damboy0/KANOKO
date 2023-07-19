using KANOKO.Dto;
using KANOKO.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace KANOKO.Auth
{
    public class JWTAuthentication : IJWTAuthentication
    {
        private readonly JwtSettings _jwtSettings;

        public JWTAuthentication(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        // public string GetUserIdentity()
        // {
        //     return _context.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
        // }

        public string GenerateToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            IList<Claim> claims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Name, user.Email),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                            new Claim(ClaimTypes.Role, user.Role.ToString()),
                            new Claim(ClaimTypes.Email, user.Email),
                        };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return tokenHandler.WriteToken(jwtSecurityToken);
        }
        public JwtSecurityToken GetClaims(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {

                var handler = new JwtSecurityTokenHandler();

                var decodedToken = handler.ReadToken(token) as JwtSecurityToken;

                return decodedToken;
            }
            return null;
        }

        /*public string GetClaimValue(string token, string type)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var decodedToken = handler.ReadToken(token) as JwtSecurityToken;

                
                var claim = decodedToken.Claims.FirstOrDefault(c => c.Type == type);

                
                return claim?.Value;
            }

            return null;
        }*/

        public string GenerateSalt()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
