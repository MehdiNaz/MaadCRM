using LanguageExt;

namespace Application.Services.Login.Queries;

public class VerifyCodeQuery : IRequest<Option<User>>
{
    public required string Phone { get; set; }
    public required string Code { get; set; }
}