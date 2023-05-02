namespace WebApi.Routes.Customers;

public static class CustomerActivityRoute
{
    public static void MapCustomerActivityRoute(this IEndpointRouteBuilder app)
    {
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

        plan.MapGet("/ById/{customerActivityId}", async (Ulid customerActivityId, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerActivityByIdQuery
                {
                    CustomerActivityId = customerActivityId
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

        plan.MapDelete("/Delete/{id}", async (Ulid id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomerActivityCommand
                {
                    Id = id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
    }
}