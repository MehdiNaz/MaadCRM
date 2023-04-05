namespace Application.Services.Login.Queries;

public abstract class GetUserByPhoneNumberQuery : RequestLoginByPhone, IRequest<IdentityUser?>
{
}