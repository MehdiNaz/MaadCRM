namespace Application.Services.Login.Queries;

public class UserByEmailAddressQuery : IRequest<Result<User>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}