using System.Reflection;
using MediatR;
using WebApi.Routes;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

#region Services

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

LogConfiguration.Configuration(builder);

CorsConfiguration.Configure(builder.Services, myAllowSpecificOrigins);

DataBaseConnectionConfiguration.Configure(builder.Services, configuration);

IdentityConfiguration.Configure(builder.Services, configuration);

SwaggerConfiguration.Configure(builder.Services);

RepositoryConfiguration.Configure(builder.Services);

RateLimiterConfiguration.Configure(builder.Services);

ServiceConfiguration.Configuration(builder.Services);

FluentValidationConfiguration.Configure(builder.Services);
#endregion

#region App
var app = builder.Build();

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
app.MapPlanRoute();

// app.MapGet("/test123",  (IMediator _mediator) => Results.Ok("test 1234"));
app.MapGet("/test123",  () => Results.Ok("test 1234"));

#endregion

app.Run();