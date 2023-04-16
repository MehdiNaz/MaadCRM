namespace Application.Services.Login.Commands;

public class RegisterUserCommand : IRequest<Option<bool>>
{
    public required string Phone { get; set; }
}