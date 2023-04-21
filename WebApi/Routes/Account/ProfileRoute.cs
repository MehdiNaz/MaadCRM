using LanguageExt;

namespace WebApi.Routes.Account;

public static class ProfileRoute
{
    public static void MapProfileRoute(this IEndpointRouteBuilder app)
    {
        var profile = app.MapGroup("v1/profile")
            .WithOpenApi()
            .AllowAnonymous();

        profile.MapPost("/SetProfile",
             ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] SetProfileCommand request,
                IMediator mediator, HttpContext httpContext) =>
            {
                try
                {
                    var authHeader = httpContext.Request.Headers["Authorization"].ToString();
                    var id = mediator.Send(new DecodeTokenQuery
                    {
                        Token = authHeader,
                        ReturnType = TokenReturnType.UserId
                    });

                    return id.Result.Match<IResult>(
                        r =>
                        {
                            var resultVerifyCode = mediator.Send(request with { Id = r });

                            return resultVerifyCode.Result.Match<IResult>(
                                user => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Done",
                                    User = user
                                }),
                                exception => Results.BadRequest(new ErrorResponse
                                {
                                    Valid = false,
                                    Exceptions = exception
                                }));
                        },
                        exception => Results.BadRequest(new ErrorResponse
                        {
                            Valid = false,
                            Exceptions = exception
                        }));
                }
                catch (ArgumentException e)
                {
                    return Results.BadRequest(new ErrorResponse
                    {
                        Valid = false,
                        Exceptions = e
                    });
                }
            });
    }
}