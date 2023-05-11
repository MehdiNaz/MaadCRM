namespace WebApi.Routes.Customers.PeyGiry;

public static class CustomerPeyGiryRoute
{
    public static void MapCustomerPeyGiryRoute(this IEndpointRouteBuilder app)
    {
        var plan = app.MapGroup("v1/CustomerPeyGiry")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllCustomerPeyGiries/{customerId}", (Ulid customerId, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new AllCustomerPeyGiriesQuery
                            {
                                CustomerId = customerId
                            });

                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show All Customers PeyGiry",
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

        plan.MapGet("/ById/{customerPeyGiryId}", (Ulid customerPeyGiryId, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new CustomerPeyGiryByIdQuery
                    {
                        CustomerPeyGiryId = customerPeyGiryId
                    });
                    return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Show Customer PeyGiry By Id",
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

        plan.MapPost("/Insert", ([FromBody] CreateCustomerPeyGiryCommand request, IMediator mediator, HttpContext httpContext) =>
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
                    var result = mediator.Send(new CreateCustomerPeyGiryCommand
                    {
                        IdUser = userId,
                        Description = request.Description,
                        DatePeyGiry = request.DatePeyGiry,
                        CustomerId = request.CustomerId,
                    });

                    return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Get Customers PeyGiry.",
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

        plan.MapPost("/ChangeStatus", ([FromBody] ChangeStatusCustomerPeyGiryCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new ChangeStatusCustomerPeyGiryCommand
                            {
                                CustomerPeyGiryId = request.CustomerPeyGiryId,
                                CustomerPeyGiryStatusType = request.CustomerPeyGiryStatusType
                            });
                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customers Note StatusType Changed.",
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

        plan.MapPut("/Update", ([FromBody] UpdateCustomerPeyGiryCommand request, IMediator mediator, HttpContext httpContext) =>
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
                            var result = mediator.Send(new UpdateCustomerPeyGiryCommand
                            {
                                Id = request.Id,
                                Description = request.Description,
                                DatePeyGiry = request.DatePeyGiry,
                                IdUser = userId
                            });
                            return result.Result.Match(
                                succes => Results.Ok(new
                                {
                                    Valid = true,
                                    Message = "Customer PeyGiry Updated.",
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

        plan.MapDelete("/Delete/{id}", async (Ulid id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomerPeyGiryCommand
                {
                    Id = id
                });

                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Business Deleted.",
                        Data = u
                    }),
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
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
    }
}