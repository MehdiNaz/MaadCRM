namespace WebApi.Routes;

public static class CustomerActivityRoute
{
    public static void MapCustomerActivityRoute(this IEndpointRouteBuilder app)
    {
        #region CustomerActivity

        var plan = app.MapGroup("v1/CustomerActivity")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllCustomerActivities", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllItemsCustomerActivitiesQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById", async ([FromBody] CustomerActivityByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerActivityByIdQuery
                {
                    CustomerActivityId = request.CustomerActivityId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateCustomerActivityCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomerActivityCommand
                {
                    CustomerActivityName = request.CustomerActivityName,
                    CustomerActivityDescription = request.CustomerActivityDescription,
                    CustomerId = request.CustomerId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateCustomerActivityCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomerActivityCommand
                {
                    CustomerActivityId = request.CustomerActivityId,
                    CustomerActivityName = request.CustomerActivityName,
                    CustomerActivityDescription = request.CustomerActivityDescription,
                    CustomerId = request.CustomerId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteCustomerActivityCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomerActivityCommand
                {
                    CustomerActivityId = request.CustomerActivityId,
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