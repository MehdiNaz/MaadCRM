using Application.Services.CoWorkers.Query;

namespace WebApi.Routes.CoWorkers;

public static class CoWorkersRoute
{
    public static RouteGroupBuilder MapCoWorkersRoute(this RouteGroupBuilder coWorker)
    {
        // TODO: Change method to put
        coWorker.MapPut("/Add",
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
        
        coWorker.MapPost("/Edit",
                    ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] EditCoworkerCommand request,
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
                                            Message = "همکار با موفقیت ویرایش شد",
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
         
         coWorker.MapGet("/GetByID/{{idU:String}}", (string idU, IMediator mediator, HttpContext httpContext) =>
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
                                             var resultAddCoWorkerGroup = mediator.Send(new GetUserByIdQuery
                                             {
                                                 IdUser = idUser,
                                                 Id = idU
                                             });
                 
                                             return resultAddCoWorkerGroup.Result.Match<IResult>(
                                                 result => Results.Ok(new
                                                 {
                                                     Valid = true,
                                                     Message ="اطلاعات همکار",
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
         
         coWorker.MapPost("/All",
                             ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] AllUsersQuery request,IMediator mediator, HttpContext httpContext) =>
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
                                                     Message = "لیست همکاران",
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
                    
         coWorker.MapDelete("/Delete",
                    ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] DeleteCoworkerCommand request,
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
                                            Message = "همکار با موفقیت حذف شد",
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
        
         
         
         
         
         
         
         
         
         
         
        // TODO: Change method to put
        coWorker.MapPut("/AddGroup",
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
            
        coWorker.MapPost("/EditGroup",
                    ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] EditCoworkerGroupCommand request,
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
                                            Message = "گروه همکاران با موفقیت ویرایش شد",
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
         
         coWorker.MapGet("/GetGroupByID/{{idg:Ulid}}", (Ulid idg, IMediator mediator, HttpContext httpContext) =>
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
                                             var resultAddCoWorkerGroup = mediator.Send(new GetUserGroupByIdQuery
                                             {
                                                 IdUser = idUser,
                                                 Id = idg
                                             });
                 
                                             return resultAddCoWorkerGroup.Result.Match<IResult>(
                                                 result => Results.Ok(new
                                                 {
                                                     Valid = true,
                                                     Message = "لیست گروه همکاران با موفقیت ارسال شد",
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
         
         coWorker.MapPost("/AllGroups",
                             ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] AllUserGroupsQuery request,IMediator mediator, HttpContext httpContext) =>
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
                    
         coWorker.MapDelete("/DeleteGroup",
                    ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] DeleteCoworkerGroupCommand request,
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
                                            Message = "گروه همکاران با موفقیت حذف شد",
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