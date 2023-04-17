namespace Application.Services.Login.Queries;

public class UserByEmailAddressQuery : IRequest<Option<User>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}