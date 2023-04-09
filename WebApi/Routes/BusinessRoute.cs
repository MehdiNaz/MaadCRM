namespace WebApi.Routes;

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
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById", async ([FromBody] BusinessByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new BusinessByIdQuery
                {
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
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
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
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
                    //CustomerId = request.CustomerId,
                    //ContactId = request.ContactId,
                    //ContactGroupId = request.ContactGroupId,
                    //AttributeOptionsId = request.AttributeOptionsId,
                    //AttributeOptionsValueId = request.AttributeOptionsValueId,
                    //BusinessAttributeId = request.BusinessAttributeId,
                    //BusinessStatus = request.BusinessStatus
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteBusinessCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteBusinessCommand
                {
                    BusinessId = request.BusinessId,
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        #endregion
    }
}