namespace WebApi.Routes.Account;

public static class LoginRoute
{
    public static RouteGroupBuilder MapLoginRoute(this RouteGroupBuilder login)
    {
        
        login.MapGet("/weatherforecast", GetWeatherForecasts)
            .WithName("GetWeatherForecasts")
            .WithOpenApi();
        
        login.MapPost("/loginWithPhone",  ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByPhoneNumberQuery request,IMediator mediator) =>
        {
            try
            {
                var resultUserByPhoneNumberQuery = mediator.Send(new UserByPhoneNumberQuery
                {
                    Phone = request.Phone
                });

                return resultUserByPhoneNumberQuery.Result.Match<IResult>(
                    r => Results.Ok(new
                {
                    Valid = r,
                    Message = "Otp sent",
                }), 
                    exception => Results.BadRequest(new
                {
                    Valid = false,
                    Message = exception,
                }));
            }
            catch (Exception e)
            {
                return Results.BadRequest(new
                {
                    Valid = false,
                    e.Message,
                    e.StackTrace
                });
            }
        });
        
        login.MapPost("/loginWithEmail",  ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByEmailAddressQuery request) =>
        {
            try
            {
                // TODO: Login with email
                return Results.Ok("Login with phone " + request.Email + " Password: " + request.Password);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
        
        login.MapPost("/loginWithPhoneAndPass",  ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByPhoneAndPasswordQuery request) =>
        {
            try
            {
                // TODO Login With Phone And Password
                
                return Results.Ok("Login with phone: " + request.Phone + " Password: " + request.Password);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        login.MapPost("/verifyPhone",  ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] VerifyCodeQuery request,IMediator mediator) =>
        {
            try
            {
                var resultVerifyCode = mediator.Send(new VerifyCodeQuery
                {
                    Phone = request.Phone,
                    Code = request.Code
                });
                
                return resultVerifyCode.Result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Verify code success",
                        Data = u
                    }), 
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
                    }));

            }
            catch (Exception e)
            {
                return Results.BadRequest(new
                {
                    Valid = false,
                    e.Message,
                    e.StackTrace
                });
            }
        });

        return login;
    }
    
    public static IResult GetWeatherForecasts()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            )).ToArray();

        return Results.Ok(forecast);
    }
}


public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}