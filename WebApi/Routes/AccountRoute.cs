namespace WebApi.Routes;

public static class AccountRoute
{
    public static void MapAccountRoute(this IEndpointRouteBuilder app)
    {
        #region Account

        var account = app.MapGroup("v1/account")
            .WithOpenApi()
            .AllowAnonymous();

        account.MapGet("/loginWithPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] UserByPhoneNumberQuery request, IMediator _mediator) =>
        {
            try
            {
                var result = _mediator.Send(new UserByPhoneNumberQuery
                {
                    Phone = request.Phone
                });
                return Results.Ok(result);
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
                return Results.Ok("Login with phone: " + request.Phone + " Password: " + request.Password);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        account.MapGet("/verifyPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] VerifyCodeQuery request) =>
        {
            try
            {
                return Results.Ok("Verify phone: " + request.Phone + " Code: " + request.Code);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        #endregion
    }
}
