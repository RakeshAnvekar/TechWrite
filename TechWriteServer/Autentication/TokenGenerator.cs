using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.DbContext;
using TechWriteServer.Enums;
using TechWriteServer.Helpers.Interfaces;
using TechWriteServer.Models.User;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.Autentication;

public sealed class TokenGenerator : ITokenGenerator
{
    #region Properties
    private readonly IConfiguration _configuration;
    #endregion

    #region Constructors
    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #endregion

    #region Methods
    public async Task<string?> GenerateTokenAsync(User user, CancellationToken cancellationToken)
    {
        //Claims are pieces of information about the user that are stored in the token.
        var claims = new[]
       {
            new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, ((UserTypes)user.UserTypeId).ToString()),
            new Claim("UserEmailId",user.UserEmailId)
        }; 
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));

        var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
            expires: DateTime.UtcNow.AddHours(1), signingCredentials: signin);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        if (string.IsNullOrEmpty(tokenValue)) return "";
        return await Task.FromResult(tokenValue);
    }
    #endregion

}
