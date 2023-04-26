namespace WebApi.Routes.Customers;

public static class CustomerActivityRoute
{
    public static void MapCustomerActivityRoute(this IEndpointRouteBuilder app)
    {
        #region CustomerActivity

        var plan = app.MapGroup("v1/CustomerActivity")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapPost("/AllCustomerActivities", async ([FromBody] AllItemsCustomerActivitiesQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllItemsCustomerActivitiesQuery
                {
                    CustomerId = request.CustomerId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ById", async ([FromBody] CustomerActivityByIdQuery request, IMediator mediator) =>
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
                    Id = request.Id,
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

        plan.MapDelete("/Delete/{Id}", async (Ulid Id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomerActivityCommand
                {
                    Id = Id
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