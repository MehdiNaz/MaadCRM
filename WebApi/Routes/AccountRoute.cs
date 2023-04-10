namespace WebApi.Routes;

public static class AccountRoute
{
    public static void MapAccountRoute(this IEndpointRouteBuilder app)
    {
        #region Account

        var account = app.MapGroup("v1/account")
            .WithOpenApi()
            .AllowAnonymous();

        account.MapGet("/loginWithPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByPhoneNumberQuery request, IMediator mediator) =>
        {
            try
            {
                var result = mediator.Send(new UserByPhoneNumberQuery
                {
                    Phone = request.Phone
                });
                if (result.Result == null)
                {
                    var resultRegister = mediator.Send(new RegisterUserCommand
                    {
                        Phone = request.Phone
                    });
                    // TODO: Check if register is ok

                    Console.WriteLine(resultRegister.Result);
                }


                var resultSendVerifyCode = mediator.Send(new SendVerifyCommand
                {
                    Phone = request.Phone
                });

                return Results.Ok(resultSendVerifyCode.Result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });


        account.MapGet("/loginWithEmail", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByEmailAddressQuery request) =>
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

        account.MapGet("/loginWithPhoneAndPass", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByPhoneAndPasswordQuery request) =>
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

        account.MapGet("/verifyPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] VerifyCodeQuery request, IMediator mediator) =>
        {
            // try
            // {
            var resultVerifyCode = mediator.Send(new VerifyCodeQuery
            {
                Phone = request.Phone,
                Code = request.Code
            });

            if (resultVerifyCode.Result == null)
                return Results.BadRequest(new
                {
                    Valid = false,
                    Message = "Verify code failed",
                    User = new IdentityUser(),
                    Token = ""
                });


            // var token = mediator.Send(new GenerateTokenQuery
            // {
            //     Phone = request.Phone,
            //     Code = request.Code
            // });

            var response = new
            {
                Valid = true,
                Message = "Verify code success",
                User = resultVerifyCode,
                Token = "token"
            };

            return Results.Ok(response);
            // }
            // catch (ArgumentException e)
            // {
            //     var response = new
            //     {
            //         Valid = false,
            //         Message = e.ParamName,
            //         User = new IdentityUser(),
            //         Token = ""
            //     };
            //     return Results.BadRequest(response);
            // }
        });

        #endregion
    }
}
