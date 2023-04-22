namespace Application.Services.Login.Commands;

public class RegisterUserCommand : IRequest<Result<bool>>
{
    public required string Phone { get; set; }
}