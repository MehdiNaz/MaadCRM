namespace Application.Interfaces.Login;

public interface ILoginOperation
{
    ValueTask<IdentityUser?> CheckExistPhone(GetUserByPhoneNumberQuery request);
}