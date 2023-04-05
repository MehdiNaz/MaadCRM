namespace Application.Services.Login.Queries;

public abstract class GetUserByPhoneAndPasswordQuery : RequestLoginByPhoneAndPassword, IRequest<bool>
{
}