namespace Application.Services.Jwt.Query;

public class DecodeTokenQuery : IRequest<Result<string>>
{
    public required string Token { get; set; }
    public required TokenReturnType ReturnType { get; init; }
}