namespace WebApi.Test;

public static class TestRoute
{
    public static void MapTestRoute(this IEndpointRouteBuilder app)
    {
        var test = app.MapGroup("v1/test")
            .WithOpenApi()
            .AllowAnonymous();

        test.MapPost("/addrole",
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
        
        test.MapGet("/test123", (IMediator _mediator) =>
        {
            var result = _mediator.Send(new GetAllBeachesQuery());
            return Results.Ok(result);
        });
        test.MapGet("/test1234", () => Results.Ok("test 1234"));
    }
}