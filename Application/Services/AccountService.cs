namespace Application.Services;

public interface IAccountService
{
    Task<ResponseAccount> Login(RequestLoginByMail model);
    Task<ResponseAccount> Register(RequestRegister model);
    JwtSecurityToken GetToken(List<Claim> authClaims);
}

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogService _logService;
    private readonly IConfiguration _configuration;

    public AccountService(
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration,
        ILogService logService
    )
    {
        _userManager = userManager;
        _configuration = configuration;
        _logService = logService;
    }


    public async Task<ResponseAccount> Login(RequestLoginByMail model)
    {
        var user = await _userManager.FindByNameAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            return new ResponseAccount
            {
                Errors = new List<string>
                {
                    "Email or password is invalid"
                },
                Message = "",
                Token = "",
                Valid = false,
                StatusCode = 401
            };

        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id),
        };
        authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

        if (string.IsNullOrEmpty(user.LoginCount.ToString())) user.LoginCount = 0;
        user.LoginCount++;
        user.LastLogin = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);

        // await _logService.Add(user.Id, LogKinds.Login);

        var token = GetToken(authClaims);
        return new ResponseAccount
        {
            Message = "",
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Valid = true,
            StatusCode = 200,
            UserRole = userRoles.FirstOrDefault()
        };
    }

    public async Task<ResponseAccount> Register(RequestRegister model)
    {
        // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return new ResponseAccount
            {
                Errors = result.Errors.Select(error => error.Description).ToList(),
                Message = "",
                Token = "",
                Valid = false,
                StatusCode = 401
            };

        await _userManager.AddToRoleAsync(user, UserRole.Company);

        // await _logService.Add(user.Id, LogKinds.Register);

        var resultOk = new ResponseAccount
        {
            Message = "",
            Token = "",
            Valid = false,
            StatusCode = 200
        };

        if (!_userManager.Options.SignIn.RequireConfirmedAccount)
            return await Login(new RequestLoginByMail
            {
                Email = model.Email,
                Password = model.Password
            });

        //// send verification email
        // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        // var callbackUrl = Url.Page(
        //     "/Account/ConfirmEmail",
        //     pageHandler: null,
        //     values: new { area = "Identity", userId = user.Id, code = code },
        //     protocol: Request.Scheme);
        // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
        //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        resultOk.Message = "Please Confirm your email.";
        return resultOk;
    }

    public JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(10),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}