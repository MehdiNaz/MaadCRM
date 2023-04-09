using Application.Services.Login.Commands;

namespace DataAccess.Repositories.Login;

public class LoginRepository : ILoginRerpository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly MaadContext _context;

    public LoginRepository(UserManager<User> userManager, SignInManager<User> signInManager,MaadContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public async ValueTask<IdentityUser?> CheckExistByPhone(UserByPhoneNumberQuery request)
    {
        // try
        // {
            var result =  await _userManager.FindByNameAsync(request.Phone);
            return result;
        // }
        // catch
        // {
            // return null;
        // }
    }

    public async ValueTask<IdentityUser?> CheckExistByEmailAddress(UserByEmailAddressQuery request)
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

    public async ValueTask<bool> CheckExistByPhoneAndPassword(UserByPhoneAndPasswordQuery request)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(request.Phone, request.Password, true, false);
            return result.Succeeded;
        }
        catch
        {
            return false;
        }
    }

    public async ValueTask<IdentityUser?> VerifyCode(VerifyCodeQuery request)
    {
        var result = await _userManager.FindByNameAsync(request.Phone);
        if (result == null)
            return null;

        return result.OtpPassword != request.Code ? null : result;
    }

    public async ValueTask<bool> SendVerifyCode(SendSMSCommand request)
    {
        var result = await _userManager.FindByNameAsync(request.Phone);
        if (result == null)
            return false;
        
        
        
        var generator = new Random();
        result.OtpPassword =  generator.Next(0, 10000).ToString("D6");
        
        _context.Users.Update(result);
        // TODO: Send SMS
        
        Console.WriteLine("OTP: " + result.OtpPassword);
        
        return true;
    }

    public async ValueTask<bool> RegisterUser(RegisterUserCommand request)
    {
        var newBusiness = new Business()
        {
            BusinessName = " شرکت" + request.Phone
        };
        await _context.Businesses!.AddAsync(newBusiness);
        var result = await _context.SaveChangesAsync();
        
        var user = new User()
        {
            LoginCount = 1,
            PhoneNumber = request.Phone,
            UserName = request.Phone,
            UserStatus = Status.Show,
            BusinessId = newBusiness.BusinessId,
            CreatedOn = DateTime.UtcNow
        };
        
        var createUserResult = await _userManager.CreateAsync(user);
        
        return createUserResult.Succeeded;
    }
}