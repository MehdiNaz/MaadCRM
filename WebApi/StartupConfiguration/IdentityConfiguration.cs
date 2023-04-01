namespace WebApi.StartupConfiguration;

public static class IdentityConfiguration
{
    public static void Configure(IServiceCollection collection, ConfigurationManager configuration)
    {
        collection.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;


                // user settings
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                // options.user.AllowedUserNameCharacters = "0123456789";
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<MaadContext>();


        collection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"] ?? "JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"))
                };



                // config.TokenValidationParameters = new TokenValidationParameters()
                // {
                //     ValidateAudience = false,
                //     ValidateIssuer = false,
                // };
                // config.Events = new JwtBearerEvents()
                // {
                //     OnMessageReceived = (ctx) =>
                //     {
                //         if (ctx.Request.Query.ContainsKey("t"))
                //         { 
                //             ctx.Token = ctx.Request.Query["t"];
                //         }
                //
                //         return Task.CompletedTask;
                //     }
                // };
                // config.Configuration = new OpenIdConnectConfiguration()
                // {
                //     SigningKeys = 
                //     {
                //         new RsaSecurityKey(rsaKey)
                //     }
                // };
                // config.MapInboundClaims = false;
            });



        collection.AddAuthorization(o =>
        {
            o.AddPolicy(UserRoleTypes.Admin, policy => policy.RequireRole(UserRoleTypes.Admin));
            o.AddPolicy(UserRoleTypes.Company, policy => policy.RequireRole(UserRoleTypes.Company));
            o.AddPolicy(UserRoleTypes.User, policy => policy.RequireRole(UserRoleTypes.User));
        });
    }
}