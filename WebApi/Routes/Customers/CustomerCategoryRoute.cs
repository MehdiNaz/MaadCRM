namespace WebApi.Routes.Customers;

public static class CustomerCategoryRoute
{
    public static void MapCustomerCategoryRoute(this IEndpointRouteBuilder app)
    {
        #region CustomerCategory

        RouteGroupBuilder plan = app.MapGroup("v1/CustomerCategory")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapPost("/AllCustomerCategories/{id}", async (string id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllItemsCustomerCategoryQuery { UserId = id });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ById", async ([FromBody] CustomerCategoryByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerCategoryByIdQuery
                {
                    CustomerCategoryId = request.CustomerCategoryId,
                    UserId = request.UserId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateCustomerCategoryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomerCategoryCommand
                {
                    UserId = request.UserId,
                    CustomerCategoryName = request.CustomerCategoryName
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomerCategoryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusCustomerCategoryCommand
                {
                    CustomerCategoryId = request.CustomerCategoryId,
                    CustomerCategoryStatus = request.CustomerCategoryStatus
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateCustomerCategoryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomerCategoryCommand
                {
                    UserId = request.UserId,
                    CustomerCategoryId = request.CustomerCategoryId,
                    CustomerCategoryName = request.CustomerCategoryName,
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteCustomerCategoryCommand request, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new DeleteCustomerCategoryCommand
                {
                    CustomerCategoryId = request.CustomerCategoryId,
                    UserId = request.UserId
                }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        #endregion
    }
}