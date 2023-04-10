using Domain.Models.IdentityModels;

namespace Application.Services.Login.Queries;

public class VerifyCodeQuery : IRequest<User?>
{
    public required string Phone { get; set; }
    public required string Code { get; set; }
}