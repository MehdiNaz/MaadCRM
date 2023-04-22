namespace Application.Services.Login.Queries;

public class UserByPhoneAndPasswordQuery : IRequest<Result<bool>>
{
    public required string Phone { get; set; }
    public required string Password { get; set; }
}