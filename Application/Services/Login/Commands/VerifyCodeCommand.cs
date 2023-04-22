namespace Application.Services.Login.Commands;

public class SendVerifyCommand:IRequest<Result<bool>>
{
    public required string Phone { get; init; }
}