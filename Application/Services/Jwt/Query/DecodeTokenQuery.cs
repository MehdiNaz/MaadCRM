namespace Application.Services.Jwt.Query;

public class DecodeTokenQuery : IRequest<string>
{
    public required string Token { get; set; }
    public TokenReturnType ReturnType { get; set; }
}