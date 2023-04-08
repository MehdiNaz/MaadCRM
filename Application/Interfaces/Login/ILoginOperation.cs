namespace Application.Interfaces.Login;

public interface ILoginOperation
{
    ValueTask<IdentityUser?> CheckExistByPhone(UserByPhoneNumberQuery request);
    ValueTask<IdentityUser?> CheckExistByEmailAddress(UserByEmailAddressQuery request);
    ValueTask<bool> CheckExistByPhoneAndPassword(UserByPhoneAndPasswordQuery request);
}