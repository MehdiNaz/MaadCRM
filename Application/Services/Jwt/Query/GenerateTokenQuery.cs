using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services.Jwt.Query;

public class GenerateTokenQuery:IRequest<JwtSecurityToken>
{
    public IList<Claim> AuthClaims { get; set; }
}