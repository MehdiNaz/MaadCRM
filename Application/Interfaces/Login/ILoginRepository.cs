using Application.Services.Login.Commands;

namespace Application.Interfaces.Login;

public interface ILoginRerpository
{
    ValueTask<IdentityUser?> CheckExistByPhone(UserByPhoneNumberQuery request);
    ValueTask<IdentityUser?> CheckExistByEmailAddress(UserByEmailAddressQuery request);
    ValueTask<bool> CheckExistByPhoneAndPassword(UserByPhoneAndPasswordQuery request);
    
    ValueTask<IdentityUser?> VerifyCode(VerifyCodeQuery request);
    ValueTask<bool> SendVerifyCode(SendSMSCommand request);
    ValueTask<bool> RegisterUser(RegisterUserCommand request);
}