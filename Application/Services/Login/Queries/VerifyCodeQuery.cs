namespace Application.Services.Login.Queries;

public class VerifyCodeQuery : IRequest<IdentityUser?>
{
    public required string Phone { get; set; }
    public required string Code { get; set; }
}