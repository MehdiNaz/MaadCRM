namespace WebApi.Routes.CoWorkers;

public static class CoWorkersRoute
{
    public static RouteGroupBuilder MapCoWorkersRoute(this RouteGroupBuilder coWorker)
    {
        coWorker.MapPost("/Add",
             ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] AddCoworkerCommand request,
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

                    return id.Result.Match(
                        idUser =>
                        {
                            var resultAddCoWorker = mediator.Send(request with
                            {
                                IdUser = idUser
                            });

                            return resultAddCoWorker.Result.Match<IResult>(
                                result => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = " همکار با موفقیت ثبت شد"
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
        
        
        coWorker.MapPost("/AddGroup",
            ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] AddCoworkerGroupCommand request,
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

                    return id.Result.Match(
                        idUser =>
                        {
                            var resultAddCoWorkerGroup = mediator.Send(request with
                            {
                                IdUser = idUser
                            });

                            return resultAddCoWorkerGroup.Result.Match<IResult>(
                                result => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "گروه همکاران با موفقیت ثبت شد",
                                    data = result
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
        return coWorker;
    }
}