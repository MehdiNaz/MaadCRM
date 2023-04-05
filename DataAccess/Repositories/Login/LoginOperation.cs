using Application.Services.Login.Queries;

namespace DataAccess.Repositories.Login;

public class LoginOperation : ILoginOperation
{
    private readonly UserManager<User> _userManager;

    public LoginOperation(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async ValueTask<IdentityUser?> CheckExistPhone(GetUserByPhoneNumberQuery request)
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
}