namespace WebApi.Routes.Notification;

public static class NotificationRout
{
    public static RouteGroupBuilder MapNotificationRoute(this RouteGroupBuilder notif)
    {
        notif.MapGet("/AllNotifications", (IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = userId
                        });

                        return business.Result.Match(bId =>
                            {
                                var result = mediator.Send(new AllNotificationsQuery
                                {
                                    IdUser = userId
                                });


                                return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Show All Notifications.",
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
        
        notif.MapGet("/NotificationById/{notId}", (Ulid notId, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = userId
                        });

                        return business.Result.Match(bId =>
                            {
                                var result = mediator.Send(new NotificationsByIdQuery
                                {
                                    IdUser = userId,
                                    IdNotification = notId
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
        
        notif.MapGet("/NotificationCount", (IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = userId
                        });

                        return business.Result.Match(bId =>
                            {
                                var result = mediator.Send(new CountNotificationsQuery
                                {
                                    IdUser = userId
                                });


                                return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Show Counts of notifications.",
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
        
        notif.MapPost("/NotificationCompleted", ([FromBody] NotificationCompletedCommand request,IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = userId
                        });

                        return business.Result.Match(bId =>
                            { 
                                var result = mediator.Send(request with
                                {
                                    IdUser = userId
                                });


                                return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Change notification to completed.",
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
        
        notif.MapPost("/NotificationCancel", ([FromBody] NotificationCanceledCommand request,IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = userId
                        });

                        return business.Result.Match(bId =>
                            {
                                var result = mediator.Send(request with
                                {
                                    IdUser = userId
                                });


                                return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Change notification to Cancel.",
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
        
        notif.MapPost("/NotificationLater", ([FromBody] NotificationLaterCommand request,IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    userId =>
                    {
                        var business = mediator.Send(new GetBusinessNameByUserIdQuery
                        {
                            UserId = userId
                        });

                        return business.Result.Match(bId =>
                            {
                                var result = mediator.Send(request with
                                {
                                    IdUser = userId
                                });


                                return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Change notification to Later.",
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
        
        return notif;
    }
}
