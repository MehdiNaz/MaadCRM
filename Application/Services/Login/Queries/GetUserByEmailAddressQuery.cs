namespace Application.Services.Login.Queries;

public abstract class GetUserByEmailAddressQuery : RequestLoginByMail, IRequest<IdentityUser?>
{
}