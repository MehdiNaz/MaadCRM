namespace Application.Interfaces.Login;

public interface ILoginOperation
{
    ValueTask<IdentityUser?> CheckExistByPhone(GetUserByPhoneNumberQuery request);
    ValueTask<IdentityUser?> CheckExistByEmailAddress(GetUserByEmailAddressQuery request);
    ValueTask<bool> CheckExistByPhoneAndPassword(GetUserByPhoneAndPasswordQuery request);
}