namespace DataAccess.Repositories.Login;

public class LoginOperation : ILoginOperation
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public LoginOperation(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async ValueTask<IdentityUser?> CheckExistByPhone(GetUserByPhoneNumberQuery request)
    {
        try
        {
            return await _userManager.FindByNameAsync(request.Phone);
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<IdentityUser?> CheckExistByEmailAddress(GetUserByEmailAddressQuery request)
    {
        try
        {
            return await _userManager.FindByEmailAsync(request.Email);
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<bool> CheckExistByPhoneAndPassword(GetUserByPhoneAndPasswordQuery request)
    {
        try
        {
            return (await _signInManager.PasswordSignInAsync(request.Phone!, request.Password, true, false)).Succeeded;
        }
        catch
        {
            return false;
        }
    }
}