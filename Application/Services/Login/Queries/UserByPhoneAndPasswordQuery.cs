namespace Application.Services.Login.Queries;

public class UserByPhoneAndPasswordQuery : IRequest<bool>
{
    public required string Phone { get; set; }
    public required string Password { get; set; }
}