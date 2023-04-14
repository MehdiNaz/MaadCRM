using LanguageExt;

namespace Application.Interfaces.Account;

public interface ILoginRepository
{
    ValueTask<Option<bool>> CheckExistByPhone(UserByPhoneNumberQuery request);
    ValueTask<Option<User>> CheckExistByEmailAddress(UserByEmailAddressQuery request);
    ValueTask<bool> CheckExistByPhoneAndPassword(UserByPhoneAndPasswordQuery request);
    
    ValueTask<Result<User>> VerifyCode(VerifyCodeQuery request);
    ValueTask<Option<bool>> SendVerifyCode(SendVerifyCommand request);
    ValueTask<Option<bool>> RegisterUser(RegisterUserCommand request);
}