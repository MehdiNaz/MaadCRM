using Application.Services.SpecialFields.AttributeCustomerService.Commands;
using Application.Services.SpecialFields.AttributeCustomerService.Queries;

namespace WebApi.Routes.SpecialFields;

public static class AttributeCustomerRoute
{
    public static RouteGroupBuilder MapAttributeCustomerRoute(this RouteGroupBuilder attribute)
    {
        attribute.MapGet("/All/{idCustomer}", (Ulid idCustomer,IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new AllAttributesCustomerQuery{ IdUser = userId,IdCustomer = idCustomer});

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get All Customer Attributes.",
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

        attribute.MapGet("/ById/{attributeId}", (Ulid attributeId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new AttributeByIdQuery { Id = attributeId });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Get Attribute By Id.",
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

        attribute.MapPost("/ChangeStatus", ([FromBody] ChangeStatusAttributeCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new ChangeStatusAttributeCommand
                        {
                            Status = request.Status,
                            Id = request.Id
                        });

                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Attribute Status Changed.",
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

        attribute.MapPost("/Insert", ([FromBody] CreateAttributeCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(request);


                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Inserted new Attribute for Customer.",
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

        attribute.MapPut("/Update", ([FromBody] UpdateAttributeCustomerCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new UpdateAttributeCommand
                            {
                                // Id = request.Id,
                                // Label = request.Label,
                                // DisplayOrder = request.DisplayOrder,
                                // IsRequired = request.IsRequired,
                                // AttributeInputTypeId = request.AttributeInputTypeId,
                                // AttributeTypeId = request.AttributeTypeId,
                                // ValidationMinLength = request.ValidationMinLength,
                                // ValidationMaxLength = request.ValidationMaxLength,
                                // ValidationFileAllowExtension = request.ValidationFileAllowExtension,
                                // ValidationFileMaximumSize = request.ValidationFileMaximumSize,
                                // DefaultValue = request.DefaultValue,
                                // IdBusiness = bId.Id,
                                // IdUserUpdated = UserId
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

        attribute.MapDelete("/Delete/{attributeId}", (Ulid attributeId, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new DeleteAttributeCommand
                        {
                            Id = attributeId
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Customer Note Updated.",
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
        
        return attribute;
    }
}