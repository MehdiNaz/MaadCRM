namespace Application.Services.Login.Queries;

public class UserByEmailAddressQuery : IRequest<IdentityUser?>
{
    public string Email { get; set; }
    public string Password { get; set; }
}