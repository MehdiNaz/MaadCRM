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

        plan.MapGet("/AllCustomerCategories", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllItemsCustomerCategoryQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById", async ([FromBody] CustomerCategoryByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerCategoryByIdQuery
                {
                    CustomerCategoryId = request.CustomerCategoryId
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
                    CustomerCategoryName = request.CustomerCategoryName
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
                var result = await mediator.Send(new DeleteCustomerCategoryCommand
                {
                    CustomerCategoryId = request.CustomerCategoryId,
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