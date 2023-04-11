namespace Application.Services.Login.Commands;

public class RegisterUserCommand : IRequest<bool>
{
    public required string Phone { get; set; }
}