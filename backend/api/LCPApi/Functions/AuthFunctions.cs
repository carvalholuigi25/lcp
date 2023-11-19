using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LCPApi.Enums;
using LCPApi.Models;

namespace LCPApi.Functions;
public static class AuthFunctions
{
    public static IResult GenToken(WebApplicationBuilder builder, UserAuth userauth)
    {
        if (userauth.UserAuthName == builder.Configuration["userAuth:username"] && userauth.UserAuthPassword == builder.Configuration["userAuth:userpass"])
        {
            var issuer = builder.Configuration["Jwt:Issuer"];
            var audience = builder.Configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim("Role", ENRoles.Administrator.ToString()),
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
            return Results.Ok(stringToken);
        }
        return Results.Unauthorized();
    }
}