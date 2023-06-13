namespace WebApi.Routes.SpecialFields;

public static class AttributeOptionRoute
{
    public static RouteGroupBuilder MapAttributeOptionRoute(this RouteGroupBuilder attributeOption)
    {
        attributeOption.MapGet("/AllAttributeOptions", (IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new AllAttributesOptionQuery());

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Attribute Options.",
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

        attributeOption.MapGet("/ById/{attributeOptionId}", (Ulid attributeOptionId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new AttributeOptionByIdQuery { Id = attributeOptionId });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get Attribute Option By Id.",
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

        attributeOption.MapPost("/ChangeStatus", ([FromBody] ChangeStatusAttributeOptionCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new ChangeStatusAttributeOptionCommand
                        {
                            Status = request.Status,
                            Id = request.Id
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Attribute Option Status Changed.",
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

        attributeOption.MapPost("/Insert", ([FromBody] CreateAttributeOptionCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new CreateAttributeOptionCommand
                        {
                            Title = request.Title,
                            ColorSquaresRgb = request.ColorSquaresRgb,
                            DisplayOrder = request.DisplayOrder,
                            IdAttribute = request.IdAttribute
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "AttributeOption Created.",
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

        attributeOption.MapPut("/Update", ([FromBody] UpdateAttributeOptionCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new UpdateAttributeOptionCommand
                        {
                            Id = request.Id,
                            Title = request.Title,
                            ColorSquaresRgb = request.ColorSquaresRgb,
                            DisplayOrder = request.DisplayOrder
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "AttributeOption Created.",
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

        attributeOption.MapDelete("/Delete/{attributeId}", (Ulid attributeId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new DeleteAttributeOptionCommand
                        {
                            Id = attributeId
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Attribute Option Deleted.",
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
        
        return attributeOption;
    }
}