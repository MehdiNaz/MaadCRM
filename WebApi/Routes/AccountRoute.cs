using Application.Requests;
using MediatR;
using System.Net.NetworkInformation;

namespace WebApi.Routes;

public static class AccountRoute
{
    public static void MapAccountRoute(this IEndpointRouteBuilder app)
    {
        #region Account

        var account = app.MapGroup("v1/account")
            .WithOpenApi()
            .AllowAnonymous();

        account.MapGet("/loginWithPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] RequestLoginByPhone request) =>
        {
            try
            {
                //var response = await mediat (new Ping());
                //return Results.Ok();
                return Results.Ok("Login with phone " + request.Phone);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
        
        
        account.MapGet("/loginWithEmail", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] RequestLoginByMail request) =>
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
        
        account.MapGet("/loginWithPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] RequestLoginByPhoneAndPassword request) =>
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

        account.MapGet("/verifyPhone", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] RequestVerifyPhone request) =>
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

    
