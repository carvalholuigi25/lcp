using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LCPApi.Enums;
using LCPApi.Models;

namespace LCPApi.Functions;
public static class AuthFunctions
{
    public static string GenToken(IConfiguration config, UserAuth userauth)
    {
        if (userauth.UserAuthName == config["userAuth:username"] && userauth.UserAuthPassword == config["userAuth:userpass"])
        {
            var issuer = config["Jwt:Issuer"];
            var audience = config["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(config["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, ENRoles.Administrator.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, ""+userauth.UserAuthName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
        return "Unauthorized";
    }
}