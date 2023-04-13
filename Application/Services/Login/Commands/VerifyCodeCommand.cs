using LanguageExt;
using LanguageExt.Common;

namespace Application.Services.Login.Commands;

public class SendVerifyCommand:IRequest<Option<bool>>
{
    public required string Phone { get; init; }
}