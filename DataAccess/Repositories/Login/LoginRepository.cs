using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Services.Login.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace DataAccess.Repositories.Login;

public class LoginRepository : ILoginRerpository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly MaadContext _context;
    private readonly IConfiguration _configuration;

    public LoginRepository(UserManager<User> userManager, SignInManager<User> signInManager,MaadContext context, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _configuration = configuration;
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

    public async ValueTask<User?> VerifyCode(VerifyCodeQuery request)
    {
        var result = await _userManager.FindByNameAsync(request.Phone);
        if (result == null)
            return null;
        
        // return result.OtpPassword != request.Code ? null : result;
        
        var userRoles = await _userManager.GetRolesAsync(result);

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, result.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, result.Id),
        };
        authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));
        
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
    
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(10),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        
        result.Token = new JwtSecurityTokenHandler().WriteToken(token);
        
        
        return result;
    }

    public async ValueTask<bool> SendVerifyCode(SendVerifyCommand request)
    {
        var result = await _userManager.FindByNameAsync(request.Phone);
        if (result == null)
            return false;
        
        
        
        var generator = new Random();
        result.OtpPassword =  generator.Next(1000, 9999).ToString("D4");
        
        await _userManager.UpdateAsync(result);

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

            var user = new User
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