namespace Application.Services.Jwt.QueryHandel;

public class DecodeTokenHandle : IRequestHandler<DecodeTokenQuery, string?>
{
    private readonly IConfiguration _configuration;

    public DecodeTokenHandle(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Task<string?> Handle(DecodeTokenQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Token) || !request.Token.StartsWith("Bearer"))
            throw new ArgumentException("The authorization header is either empty or isn't Bearer.");

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
            throw new ArgumentException("The authorization header is either empty or isn't Bearer.");

        var dateEx = DateTimeOffset.FromUnixTimeSeconds(long.Parse(value));
        if (dateEx < DateTimeOffset.Now)
            throw new ArgumentException($"The authorization header is expired.");

        return Task.FromResult(request.ReturnType switch
        {
            TokenReturnType.UserName => principal.Identities.FirstOrDefault()?.Claims.ElementAt(0).Value,
            TokenReturnType.UserId => principal.Identities.FirstOrDefault()?.Claims.ElementAt(2).Value,
            _ => throw new ArgumentException("The authorization header is not valid.")
        });
    }
}