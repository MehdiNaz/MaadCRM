using Application.Services.Login.Commands;
using Domain.Models.IdentityModels;

namespace Application.Interfaces.Account;

public interface ILoginRerpository
{
    ValueTask<IdentityUser?> CheckExistByPhone(UserByPhoneNumberQuery request);
    ValueTask<IdentityUser?> CheckExistByEmailAddress(UserByEmailAddressQuery request);
    ValueTask<bool> CheckExistByPhoneAndPassword(UserByPhoneAndPasswordQuery request);
    
    ValueTask<User?> VerifyCode(VerifyCodeQuery request);
    ValueTask<bool> SendVerifyCode(SendVerifyCommand request);
    ValueTask<bool> RegisterUser(RegisterUserCommand request);
}