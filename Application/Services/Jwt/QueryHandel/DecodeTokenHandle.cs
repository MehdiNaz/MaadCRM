using System.Diagnostics;

namespace Application.Services.Jwt.QueryHandel;

public class DecodeTokenHandle : IRequestHandler<DecodeTokenQuery, Result<string>>
{
    private readonly IConfiguration _configuration;

    public DecodeTokenHandle(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<Result<string>> Handle(DecodeTokenQuery request, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(request.Token) || !request.Token.StartsWith("Bearer"))
                return new Result<string>(new Exception("The authorization header is either empty or isn't Bearer."));

            request.Token = request.Token.Substring("Bearer ".Length).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]!);
            var validationParameters = new TokenValidationParameters()
            {
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                ValidAudience = _configuration["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
            var principal = tokenHandler.ValidateToken(request.Token, validationParameters, out _);
            var value = principal.Identities.FirstOrDefault()?.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
            if (value == null)
                return new Result<string>(new Exception("The authorization header is either empty or isn't Bearer."));

            var dateEx = DateTimeOffset.FromUnixTimeSeconds(long.Parse(value));
            if (dateEx < DateTimeOffset.Now)
                return new Result<string>(new Exception($"The authorization header is expired."));

            return request.ReturnType switch
            {
                TokenReturnType.UserName => new Result<string>(principal.Identities.FirstOrDefault()?.Claims.ElementAt(0).Value!),
                TokenReturnType.UserId => new Result<string>(principal.Identities.FirstOrDefault()?.Claims.ElementAt(2).Value!),
                _ => new Result<string>(new Exception("The authorization header is not valid."))
            };
        }
        catch (Exception e)
        {
            return new Result<string>(new Exception("The authorization header is not valid."));
        }
        
    }
}