namespace WebApi.Routes.Notification;

public static class NotificationRout
{
    public static RouteGroupBuilder MapNotificationRoute(this RouteGroupBuilder not)
    {
        not.MapGet("/AllNotifications", (IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    UserId =>
                    {
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = UserId
                        });

                        return business.Result.Match(bId =>
                            {
                                var result = mediator.Send(new AllProductsQuery
                                {
                                    BusinessId = bId.Id
                                });


                                return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Show All Products.",
                                        Data = succes
                                    }),
                                    error => Results.BadRequest(new ErrorResponse
                                    {
                                        Valid = false,
                                        Exceptions = error
                                    }));
                            },
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
        
        
        
        return not;
    }
}
