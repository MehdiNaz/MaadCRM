using LanguageExt;
using LanguageExt.Common;

namespace Application.Services.Login.Queries;

public class VerifyCodeQuery : IRequest<Result<User>>
{
    public required string Phone { get; init; }
    public required string Code { get; init; }
}