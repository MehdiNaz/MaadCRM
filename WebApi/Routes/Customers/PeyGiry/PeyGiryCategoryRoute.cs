namespace WebApi.Routes.Customers.PeyGiry;

public static class PeyGiryCategoryRoute
{
    public static void MapPeyGiryCategoryRoute(this IEndpointRouteBuilder app)
    {
        var plan = app.MapGroup("v1/PeyGiryCategory").EnableOpenApiWithAuthentication().WithOpenApi();

        plan.MapGet("/AllPeyGiryCategories", (IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new AllPeyGiryCategoriesQuery
                            {
                                BusinessId = bId.Id
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Inserted new Attribute.",
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

        plan.MapGet("/ById/{peyGiryCategoryId}", (Ulid peyGiryCategoryId, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    _ =>
                    {
                        var result = mediator.Send(new PeyGiryCategoryByIdQuery { PeyGiryCategoryId = peyGiryCategoryId });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get PeyGiry Category By Id.",
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

        plan.MapPost("/ChangeStatus", ([FromBody] ChangeStatusAttributeCommand request, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = httpContext.Request.Headers["Authorization"].ToString(),
                    ReturnType = TokenReturnType.UserId
                });

                return id.Result.Match(
                    _ =>
                    {
                        var result = mediator.Send(new ChangeStatusPeyGiryCategoryCommand
                        {
                            Status = request.Status,
                            Id = request.Id
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "PeyGiry Category Status Changed.",
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
            catch (ArgumentException e)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Valid = false,
                    Exceptions = e
                });
            }
        });

        plan.MapPost("/Insert", ([FromBody] CreatePeyGiryCategoryCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new CreatePeyGiryCategoryCommand
                            {
                                Kind = request.Kind,
                                BusinessId = bId.Id,
                                IdUserAdded = UserId,
                                IdUserUpdated = UserId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Inserted new Attribute.",
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

        plan.MapPut("/Update", ([FromBody] UpdatePeyGiryCategoryCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new UpdatePeyGiryCategoryCommand
                            {
                                Id = request.Id,
                                Kind = request.Kind,
                                BusinessId = bId.Id,
                                IdUserUpdated = UserId
                            });


                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Inserted new Product Category.",
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

        plan.MapDelete("/Delete/{peyGiryCategoryId}", (Ulid peyGiryCategoryId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new DeletePeyGiryCategoryCommand
                        {
                            Id = peyGiryCategoryId
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "PeyGiry Category Deleted.",
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