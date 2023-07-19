using KANOKO.Dto;
using KANOKO.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace KANOKO.Auth
{
    public interface IJWTAuthentication
    {
        string GenerateToken(UserDto user);

        JwtSecurityToken GetClaims(string token);

       // string GetClaimValue(string token, string type);

        string GenerateSalt();
        Task<User> FindByNameAsync(string userName);
    }
}
