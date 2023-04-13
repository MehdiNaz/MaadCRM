using LanguageExt;

namespace WebApi.Routes.Account;
public static class LoginRoute
{
    public static void MapLoginRoute(this IEndpointRouteBuilder app)
    {
        var login = app.MapGroup("v1/login")
            .WithOpenApi()
            .AllowAnonymous();

        login.MapPost("/loginWithPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByPhoneNumberQuery request,IMediator mediator) =>
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






                // if (result.IsCompleted)
                // {
                //     
                //     
                //     // var resultRegister = mediator.Send(new RegisterUserCommand
                //     // {
                //     //     Phone = request.Phone
                //     // });
                //     // // TODO: Check if register is ok
                //     //
                //     // Console.WriteLine(resultRegister.Result);
                // }


                // var resultSendVerifyCode = mediator.Send(new SendVerifyCommand
                // {
                //     Phone = request.Phone
                // });
                //
                // return Results.Ok(new
                // {
                //     Valid = resultSendVerifyCode.Result,
                //     Message = "Otp sent",
                // });
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new
                {
                    Valid = false,
                    Message = e.Message,
                    StackTrace = e.StackTrace
                });
            }
        });
        
        
        login.MapPost("/loginWithEmail", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByEmailAddressQuery request) =>
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
        
        login.MapPost("/loginWithPhoneAndPass", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByPhoneAndPasswordQuery request) =>
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

        login.MapPost("/verifyPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] VerifyCodeQuery request,IMediator mediator) =>
        {
            try
            {
                var resultVerifyCode = mediator.Send(new VerifyCodeQuery
                {
                    Phone = request.Phone,
                    Code = request.Code
                });

                Console.WriteLine(resultVerifyCode.Result);
                if (resultVerifyCode.Result == null)
                    return Results.Unauthorized();

                return Results.Ok(new
                {
                    Valid = true,
                    Message = "Verify code success",
                    User = resultVerifyCode.Result
                });
                
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new
                {
                    Valid = false,
                    Message = e.Message,
                    StackTrace = e.StackTrace
                });
            }
        });
    }
}

    
