using System.Threading.RateLimiting;
using Application;
using Coravel;
using DataAccess;
using MaadApi;
using Microsoft.AspNetCore.RateLimiting;
using Serilog;
using WebApi.Routes;

// ============================ Builder ========================================
var builder = WebApplication.CreateBuilder(args);

// ========================== Configuration ====================================
var configuration = builder.Configuration;

// ============================ Services =======================================
#region Services

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddScheduler();

#region CORS
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                    "http://192.168.43.118:3000",
                    "http://localhost:3000"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});
#endregion

// Health Check
builder.Services.AddHealthChecks();

// DataBase connection For Entity Framework
#region DataBase_connection_For_Entity_Framework

var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<MaadContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#endregion

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
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


    // User settings
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    // options.User.AllowedUserNameCharacters = "0123456789";
})
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<MaadContext>();

// Authentication
#region Authentication
builder.Services.AddAuthentication(options =>
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

// Authorization
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy(UserRole.Admin, policy => policy.RequireRole(UserRole.Admin));
    o.AddPolicy(UserRole.Company, policy => policy.RequireRole(UserRole.Company));
    o.AddPolicy(UserRole.User, policy => policy.RequireRole(UserRole.User));
});
#endregion

// Swagger
#region Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SwaggerGeneratorOptions>(opts =>
{
    opts.InferSecuritySchemes = true;
});

#endregion


builder.Services
    .AddApplication();

// Register services
#region Register services
// builder.Services.AddTransient<ScheduleDatabaseInvocable>();

// var serviceProvider = builder.Services.BuildServiceProvider();
// var logger = serviceProvider.GetService<ILogger<ScheduleDatabaseInvocable>>();
// builder.Services.AddSingleton(typeof(ILogger), logger!);


// services
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ITestService, TestService>();
builder.Services.AddTransient<ILogService, LogService>();

#endregion

// Rate Limiter
builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 4;
        options.Window = TimeSpan.FromSeconds(12);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 2;
    }));

#endregion

builder.Host.UseSerilog((context,loggerConfiguration) => 
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

// ============================ App ============================================
#region App
var app = builder.Build();

// var provider = app.Services;
// provider.UseScheduler(scheduler =>
// {
//     scheduler.Schedule<ScheduleDatabaseInvocable>()
//     .DailyAtHour(4);
// });

app.UseCors();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseCors(myAllowSpecificOrigins);

// Setup the file server to serve static files.
app.UseFileServer();

app.UseSerilogRequestLogging();

#endregion

// ============================ Routes =========================================
#region Routes

#region MyRegion
var clients = app.MapGroup("/log")
    .AddEndpointFilterFactory((handlerContext, next) =>
    {
        var loggerFactory = handlerContext.ApplicationServices.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("RequestAuditor");
        return (invocationContext) =>
        {
            logger.LogInformation($"[⚙️] Received a request for: {invocationContext.HttpContext.Request.Path}");
            return next(invocationContext);
        };
    })
    .WithOpenApi();


// .AddEndpointFilter(async (context, next) => {
//      var client = context.GetArgument<Client>(2);
//      if (client.FirstName.Any(char.IsDigit) || client.LastName.Any(char.IsDigit))
//      {
//          return Results.Problem("Names cannot contain any numeric characters.", statusCode: 400);
//      }
//      return await next(context);
//  });


var auth = app.MapGroup("/auth")
    .RequireAuthorization("Users")
    .EnableOpenApiWithAuthentication();
auth.MapGet("/admin", () => "The /admin endpoint is for admins only.").RequireAuthorization("AdminsOnly");
auth.MapGet("/user", () => "This endpoint requires authorization.");
clients.MapGet("/", () => "This endpoint doesn't require authorization.");
app.MapGet("/Identity/Account/Login", Results.Unauthorized);

app.MapGet("/hello", (ClaimsPrincipal user) => "Hello " + user.FindFirstValue("sub"));


// app.MapGet("/jwttest", async (ITestService testService) => await testService.AddRole());

app.MapGet("/jwt", () =>
{
    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

    var authClaims = new List<Claim>
    {
         new(ClaimTypes.Name, "user.UserName"),
         new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
         new(ClaimTypes.NameIdentifier, "user.Id"),
         new(ClaimTypes.Role, UserRole.User)
    };

    var token = new JwtSecurityToken(
        issuer: configuration["JWT:ValidIssuer"],
        audience: configuration["JWT:ValidAudience"],
        expires: DateTime.Now.AddDays(10),
        claims: authClaims,
        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
    );
    return new JwtSecurityTokenHandler().WriteToken(token);
});
#endregion

app.MapAccountRouts();

#endregion
// ============================ End Routes =====================================

app.Run();


