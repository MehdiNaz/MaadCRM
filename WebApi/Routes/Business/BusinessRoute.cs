﻿namespace WebApi.Routes.Business;

public static class BusinessRoute
{
    public static RouteGroupBuilder MapBusinessRoute(this RouteGroupBuilder plan)
    {
        plan.MapGet("/AllBusinesses", (IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new AllBusinessQuery());


                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Show All Businesses.",
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

        plan.MapGet("/ById", (IMediator mediator, HttpContext httpContext) =>
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
                        var business = mediator.Send(new GetBusinessByUserIdQuery
                        {
                            UserId = UserId
                        });

                        var result = mediator.Send(new GetBusinessByUserIdQuery
                        {
                            UserId = UserId
                        });
                        return result.Result.Match(
                            succes => Results.Ok(new
                            {
                                Valid = true,
                                Message = "Show Product By Id",
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

        plan.MapPost("/Insert", async ([FromBody] CreateBusinessCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateBusinessCommand
                {
                    BusinessName = request.BusinessName,
                    Url = request.Url,
                    Hosts = request.Hosts,
                    CompanyName = request.CompanyName,
                    CompanyAddress = request.CompanyAddress,
                    DisplayOrder = request.DisplayOrder,
                    //IdUser = request.IdUser
                });

                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "New Business Inserted.",
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

        plan.MapPost("/ChangeStatus",  ([FromBody] ChangeStatusBusinessCommand request, IMediator mediator, HttpContext httpContext) =>
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
                        var result = mediator.Send(new ChangeStatusBusinessCommand
                        {
                            BusinessStatusType = request.BusinessStatusType,
                            BusinessId = request.BusinessId
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

        plan.MapPut("/Update", async ([FromBody] UpdateBusinessCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateBusinessCommand
                {
                    BusinessId = request.BusinessId,
                    BusinessName = request.BusinessName,
                    Url = request.Url,
                    Hosts = request.Hosts,
                    CompanyName = request.CompanyName,
                    CompanyAddress = request.CompanyAddress,
                    DisplayOrder = request.DisplayOrder,
                    //IdUser = request.IdUser,
                    //Id = request.Id,
                    //Id = request.Id,
                    //Id = request.Id,
                    //Id = request.Id,
                    //AttributeOptionsValueId = request.AttributeOptionsValueId,
                    //BusinessAttributeId = request.BusinessAttributeId,
                    //BusinessStatusType = request.BusinessStatusType
                });
                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Business Updated.",
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

        plan.MapDelete("/Delete/{Id}", async (Ulid Id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteBusinessCommand
                {
                    BusinessId = Id
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
        return plan;
    }
}