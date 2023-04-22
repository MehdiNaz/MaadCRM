namespace Application.Interfaces.Account;

public interface ILoginRepository
{
    ValueTask<Result<bool>> CheckExistByPhone(UserByPhoneNumberQuery request);
    ValueTask<Result<User>> CheckExistByEmailAddress(UserByEmailAddressQuery request);
    ValueTask<Result<bool>> CheckExistByPhoneAndPassword(UserByPhoneAndPasswordQuery request);
    
    ValueTask<Result<User>> VerifyCode(VerifyCodeQuery request);
    ValueTask<Result<bool>> SendVerifyCode(SendVerifyCommand request);
    ValueTask<Result<bool>> RegisterUser(RegisterUserCommand request);
}