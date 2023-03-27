namespace WebApi.Routes;

public static class AccountRouts
{
    public static void MapAccountRouts(this IEndpointRouteBuilder app)
    {
        var account = app.MapGroup(Version.V1 + "/Account/")
            .AllowAnonymous()
            .WithOpenApi();

        account.MapPost("Login", async (
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] RequestLoginByMail model,
            IAccountService accountService
        ) =>
        {
            var result = await accountService.Login(model);
            if (!result.Valid || result.StatusCode != 200)
                return Results.BadRequest(result);

            return Results.Ok(result);
        });

        account.MapPost("register", async (
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] RequestRegister model,
            IAccountService accountService
        ) =>
        {
            var result = await accountService.Register(model);
            if (!result.Valid || result.StatusCode != 200)
                return Results.BadRequest(result);

            return Results.Ok(result);
        });

        // account.MapPost("/ResetPassword", async (
        //     [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)]
        //     PasswordModel model, IUserAppService userService) =>
        // {
        //     var result = await userService.SetPassword(model.CodeMelli, model.Password);
        //     if (!result.Data.Valid || result.Status != 200)
        //         return Results.BadRequest(result);
        //     return Results.Ok(result);
        // });

    }
}
