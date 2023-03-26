// ============================ Builder ========================================
var builder = WebApplication.CreateBuilder(args);

// ========================== Declarations ====================================
ConfigurationManager configuration = builder.Configuration;
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

// ============================ Services =======================================
#region Services
LogConfiguration.Configuration(builder);


// Cors
CorsConfiguration.Configure(builder.Services, myAllowSpecificOrigins);

// Health Check
builder.Services.AddHealthChecks();

// DataBase connection For Entity Framework
DataBaseConnectionConfiguration.Configure(builder.Services, configuration);

// Identity Authentication Authorization
IdentityConfiguration.Configure(builder.Services, configuration);

// Swagger
SwaggerConfiguration.Configure(builder.Services);


builder.Services.AddApplication();

// Register services
#region Register services
// builder.Services.AddTransient<ScheduleDatabaseInvocable>();

// var serviceProvider = builder.Services.BuildServiceProvider();
// var logger = serviceProvider.GetService<ILogger<ScheduleDatabaseInvocable>>();
// builder.Services.AddSingleton(typeof(ILogger), logger!);

RepositoryConfiguration.Configure(builder.Services);


#endregion

// Rate Limiter
RateLimiterConfiguration.Configure(builder.Services);
#endregion


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
        return invocationContext =>
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

//Fluent Validation
FluentValidationConfiguration.Configure(builder.Services);

app.Run();
