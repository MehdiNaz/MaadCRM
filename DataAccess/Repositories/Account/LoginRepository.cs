namespace DataAccess.Repositories.Account;

public class LoginRepository : ILoginRepository
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

    public async ValueTask<Option<bool>> CheckExistByPhone(UserByPhoneNumberQuery request)
    {
        try
        {
            var result =  await _userManager.FindByNameAsync(request.Phone);
            return result != null ? Option<bool>.Some(true) : Option<bool>.None;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async ValueTask<Option<User>> CheckExistByEmailAddress(UserByEmailAddressQuery request)
    {
        try
        {
            var result =  await _userManager.FindByEmailAsync(request.Email);
            return result == null ? result.ToSome()! : Option<User>.None;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async ValueTask<bool> CheckExistByPhoneAndPassword(UserByPhoneAndPasswordQuery request)
    {
        try
        {
            var result =  await _signInManager.PasswordSignInAsync(request.Phone, request.Password, true, false);
            return result.Succeeded;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    
    public async ValueTask<Option<bool>> SendVerifyCode(SendVerifyCommand request)
    {
        try
        {
            var result = await _userManager.FindByNameAsync(request.Phone);
            if (result == null)
                return Option<bool>.None;
            
            var generator = new Random();
            result.OtpPassword =  generator.Next(1000, 9999).ToString("D4");
        
            result.LoginCount++;
            result.LastLogin = DateTime.UtcNow;
            result.OtpPasswordExpired = DateTime.UtcNow.AddMinutes(3);
        
            await _userManager.UpdateAsync(result);

            // TODO: Send SMS
        
            // TODO: add log
            Console.WriteLine("OTP: " + result.OtpPassword);
        
            return Option<bool>.Some(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async ValueTask<Result<User>> VerifyCode(VerifyCodeQuery request)
    {
        try
        {
            var result = await _userManager.FindByNameAsync(request.Phone);
            if (result == null || result.OtpPasswordExpired < DateTime.UtcNow)
                return new Result<User>(new ValidationException("کد وارد شده منقضی شده است"));
        
            var userRoles = await _userManager.GetRolesAsync(result);
            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, result.UserName!),
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
        
        
            return new Result<User>(result);
        }
        catch (Exception e)
        {
            return new Result<User>(new ValidationException(e.Message));
        }
        
    }

    public async ValueTask<Option<bool>> RegisterUser(RegisterUserCommand request)
    {
        try
        {
            var newBusiness = new Business()
            {
                BusinessName = " شرکت" + request.Phone
            };
            await _context.Businesses.AddAsync(newBusiness);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return Option<bool>.None;

            var user = new User
            {
                LoginCount = 1,
                PhoneNumber = request.Phone,
                UserName = request.Phone,
                UserStatus = Status.Show,
                BusinessId = newBusiness.Id,
                PhoneNumberConfirmed = true,
                CreatedOn = DateTime.UtcNow
            };

            var createUserResult = await _userManager.CreateAsync(user);

            // TODO: add role to user
            // await _userManager.AddToRoleAsync(user, UserRoleTypes.Company);

            return Option<bool>.Some(createUserResult.Succeeded);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}