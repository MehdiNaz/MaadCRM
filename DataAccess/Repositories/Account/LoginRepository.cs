namespace DataAccess.Repositories.Account;

public class LoginRepository : ILoginRepository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly MaadContext _context;
    private readonly IConfiguration _configuration;

    public LoginRepository(UserManager<User> userManager, SignInManager<User> signInManager, MaadContext context,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _configuration = configuration;
    }

    public async ValueTask<Result<bool>> CheckExistByPhone(UserByPhoneNumberQuery request)
    {
        try
        {
            var result = await _userManager.FindByNameAsync(request.Phone);
            return result != null
                ? new Result<bool>(true)
                : new Result<bool>(new ValidationException("کاربری با این شماره موبایل یافت نشد"));
        }
        catch (Exception e)
        {
            return new Result<bool>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<User>> CheckExistByEmailAddress(UserByEmailAddressQuery request)
    {
        try
        {
            var result = await _userManager.FindByEmailAsync(request.Email);
            return result != null
                ? new Result<User>(result)
                : new Result<User>(new ValidationException("کاربری با این ایمیل یافت نشد"));
        }
        catch (Exception e)
        {
            return new Result<User>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<bool>> CheckExistByPhoneAndPassword(UserByPhoneAndPasswordQuery request)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(request.Phone, request.Password, true, false);
            return new Result<bool>(result.Succeeded);
        }
        catch (Exception e)
        {
            return new Result<bool>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<bool>> SendVerifyCode(SendVerifyCommand request)
    {
        try
        {
            var result = await _userManager.FindByNameAsync(request.Phone);
            if (result == null)
                return new Result<bool>(new ValidationException("کاربری با این شماره موبایل یافت نشد"));

            var generator = new Random();
            result.OtpPassword = generator.Next(1000, 9999).ToString("D4");

            result.LoginCount++;
            result.LastLogin = DateTime.UtcNow;
            result.OtpPasswordExpired = DateTime.UtcNow.AddMinutes(3);

            await _userManager.UpdateAsync(result);

            await SendVerifySms(SmsType.Verify, request.Phone, result.OtpPassword);

            Console.WriteLine("OTP: " + result.OtpPassword);

            return new Result<bool>(true);
        }
        catch (Exception e)
        {
            return new Result<bool>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<User>> VerifyCode(VerifyCodeQuery request)
    {
        try
        {
            var result = await _userManager.FindByNameAsync(request.Phone);
            if (result?.OtpPassword != request.Code)
                return new Result<User>(new ValidationException("کد وارد شده صحیح نیست"));
            
            if (result.OtpPasswordExpired < DateTime.UtcNow)
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
                expires: DateTime.Now.AddDays(20),
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

    public async ValueTask<Result<bool>> RegisterUser(RegisterUserCommand request)
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
                return new Result<bool>(new ValidationException("خطا در ثبت اطلاعات شرکت"));
            
            var user = new User
            {
                LoginCount = 1,
                PhoneNumber = request.Phone,
                UserName = request.Phone,
                Status = StatusType.Show,
                IdBusiness = newBusiness.Id,
                PhoneNumberConfirmed = true,
                CreatedOn = DateTime.UtcNow,
                // IdGroup = newUserGroup.Id
            };

            var createUserResult = await _userManager.CreateAsync(user);

            var newUser = await _userManager.FindByNameAsync(request.Phone);
            if (newUser == null)
                return new Result<bool>(new ValidationException("خطا در ثبت اطلاعات کاربر"));
            
            ProductCategory newProductCategory = new()
            {
                Order = 0,
                ProductCategoryName = "دسته بندی پیش فرض",
                BusinessId = newBusiness.Id,
                IdUserAdded = newUser.Id,
                IdUserUpdated = newUser.Id
            };
            await _context.ProductCategories.AddAsync(newProductCategory);
            
            var newUserGroup = new UserGroup
            {
                IdBusiness = newBusiness.Id,
                IdUserAdded = newUser.Id,
                IdUserUpdated = newUser.Id,
                Title = "گروه پیش فرض"
            };

            newUser.IdGroup = newUserGroup.Id;
            
            await _context.UserGroups.AddAsync(newUserGroup);
            
            
            var resultCreateUserGroupResult = await _context.SaveChangesAsync();
            
            
            await _userManager.AddToRoleAsync(user, UserRoleTypes.User);
            await _userManager.AddToRoleAsync(user, UserRoleTypes.Company);

            return new Result<bool>(createUserResult.Succeeded);
        }
        catch (Exception e)
        {
            return new Result<bool>(new ValidationException(e.Message));
        }
    }

    private static async ValueTask<Result<bool>> SendVerifySms(SmsType smsType, string phoneNumber, string otp)
    {
        try
        {
            const string user = "maadcrm3375";
            const string pass = "jamshidi2294";
            // Sms.smsmarkazi.com

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://ippanel.com/api/select");

            var str = smsType switch
            {
                SmsType.Verify => $$"""
                                        {
                                           "op": "pattern",
                                            "user": "{{user}}",
                                            "pass": "{{pass}}",
                                            "fromNum": "3000505",
                                            "toNum": "{{phoneNumber}}",
                                            "patternCode": "hc3p46s7ehdm9l2",
                                            "inputData": [
                                                {
                                                "code": "{{otp}}"
                                                }
                                            ]
                                        }
                                    """,
                _ => $$"""
                           {
                              "op": "pattern",
                               "user": "{{user}}",
                               "pass": "{{pass}}",
                               "fromNum": "3000505",
                               "toNum": "{{phoneNumber}}",
                               "patternCode": "hc3p46s7ehdm9l2",
                               "inputData": [
                                   {
                                   "code": "{{otp}}"
                                   }
                               ]
                           }
                       """
            };

            var content = new StringContent(str, null, "application/json");
            
            request.Content = content;
            var response = await client.SendAsync(request);

            // var result = 
            await response.Content.ReadAsStringAsync();

            // int.Parse(result);
            // Console.WriteLine(result);

            
            return new Result<bool>(true);
        }
        catch (Exception e)
        {
            return new Result<bool>(e);
        }
    }
}