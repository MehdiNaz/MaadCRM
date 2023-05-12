namespace WebApi.Routes.Customers.Notes;

public static class NoteHashTableRoute
{
    public static void MapNoteHashTableRoute(this IEndpointRouteBuilder app)
    {
        #region NoteHashTable

        var plan = app.MapGroup("v1/NoteHashTable")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllNoteHashTables", (IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new AllNoteHashTableQuery
                            {
                                BusinessId = bId.Id
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show All Note Hash Tables.",
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

        plan.MapGet("/ById/{noteHashTable}", (Ulid noteHashTable, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new NoteHashTableByIdQuery { Id = noteHashTable });

                    return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Get Note Hash Table By Id.",
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

        plan.MapPost("/Insert", ([FromBody] CreateNoteHashTableCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new CreateNoteHashTableCommand
                            {
                                Title = request.Title,
                                BusinessId = bId.Id,
                                HashTagIds = request.HashTagIds
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "New Note Hash Table Inserted.",
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

        plan.MapPost("/ChangeStatus", ([FromBody] ChangeStatusNoteHashTableCommand request, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new ChangeStatusNoteHashTableCommand
                    {
                        Id = request.Id,
                        NoteHashTagStatusType = request.NoteHashTagStatusType
                    });

                    return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "StatusType of Note Hash Table Changed.",
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

        plan.MapPut("/Update", ([FromBody] UpdateNoteHashTableCommand request, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new UpdateNoteHashTableCommand
                    {
                        Id = request.Id,
                        Title = request.Title,
                    });

                    return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "UpdateAsync Note Hash Table.",
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

        plan.MapDelete("/Delete/{Id}", (Ulid Id, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new DeleteNoteHashTableCommand { Id = Id });

                    return result.Result.Match(
                                    succes => Results.Ok(new
                                    {
                                        Valid = true,
                                        Message = "Note Hash Table Deleted.",
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









            //try
            //{
            //    return Results.Ok(await );
            //}
            //catch (ArgumentException e)
            //{
            //    return Results.BadRequest(e.ParamName);
            //}
        });
        #endregion
    }
}