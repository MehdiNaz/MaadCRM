using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Services.Jwt.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Jwt.QueryHandel;

public class GenerateTokenHandle:IRequestHandler<GenerateTokenQuery, JwtSecurityToken>
{
    private readonly IConfiguration _configuration;
    
    public GenerateTokenHandle(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<JwtSecurityToken> Handle(GenerateTokenQuery request, CancellationToken cancellationToken)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
    
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(10),
            claims: request.AuthClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
    
        return Task.FromResult(token);
    }
}