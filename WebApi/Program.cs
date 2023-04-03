using WebApi.Routes;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

#region Services
// Log
LogConfiguration.Configuration(builder);

// Cors
CorsConfiguration.Configure(builder.Services, myAllowSpecificOrigins);

builder.Services.AddHealthChecks();

DataBaseConnectionConfiguration.Configure(builder.Services, configuration);

// Identity Authentication Authorization
IdentityConfiguration.Configure(builder.Services, configuration);

SwaggerConfiguration.Configure(builder.Services);

// Register services
RepositoryConfiguration.Configure(builder.Services);

RateLimiterConfiguration.Configure(builder.Services);

builder.Services.AddApplication();

FluentValidationConfiguration.Configure(builder.Services);
#endregion

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

app.UseFileServer();

app.UseSerilogRequestLogging();

#endregion

#region Routes
app.MapAccountRoute();
#endregion

app.Run();
