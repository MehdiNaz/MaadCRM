namespace WebApi.Routes.Business;

public static class BusinessRoute
{
    public static void MapBusinessRoute(this IEndpointRouteBuilder app)
    {
        #region Business

        var plan = app.MapGroup("v1/Business")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllBusinesses", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllBusinessQuery());

                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Show All Businesses.",
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

        plan.MapPost("/ById", async ([FromBody] BusinessByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new BusinessByIdQuery
                {
                    UserId = request.BusinessId
                });
                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Show Business By Id.",
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
                    //UserId = request.UserId
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

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusBusinessCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusBusinessCommand
                {
                    BusinessStatus = request.BusinessStatus,
                    BusinessId = request.BusinessId
                });

                return result.Match(
                    u => Results.Ok(new
                    {
                        Valid = true,
                        Message = "Status Business Changed.",
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
                    //UserId = request.UserId,
                    //Id = request.Id,
                    //Id = request.Id,
                    //Id = request.Id,
                    //AttributeOptionsId = request.AttributeOptionsId,
                    //AttributeOptionsValueId = request.AttributeOptionsValueId,
                    //BusinessAttributeId = request.BusinessAttributeId,
                    //BusinessStatus = request.BusinessStatus
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
        #endregion
    }
}