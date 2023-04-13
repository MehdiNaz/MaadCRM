using LanguageExt;
using LanguageExt.Common;

namespace Application.Services.Login.Queries;

public class UserByPhoneNumberQuery : IRequest<Result<bool>>
{
    public required string Phone { get; init; }
}