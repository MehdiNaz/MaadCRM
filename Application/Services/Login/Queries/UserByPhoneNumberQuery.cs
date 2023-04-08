namespace Application.Services.Login.Queries;

public class UserByPhoneNumberQuery : IRequest<IdentityUser?>
{
    public required string Phone { get; set; }
}