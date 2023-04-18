namespace WebApi.Routes.Products;

public static class ProductCategoryRoute
{
    public static void MapProductCategoryRoute(this IEndpointRouteBuilder app)
    {

        var plan = app.MapGroup("v1/ProductCategory")
                 //.RequireAuthorization()
                 .EnableOpenApiWithAuthentication()
                 .WithOpenApi();

        plan.MapPost("/AllProductCategories", async ([FromBody] AllProductCategoriesQuery request, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new AllProductCategoriesQuery
                {
                    BusinessId = request.BusinessId
                }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById/{ProductCategoryId}", async (Ulid productCategoryId, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new ProductCategoryByIdQuery { ProductCategoryId = productCategoryId }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusProductCategoryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusProductCategoryCommand
                {
                    ProductCategoryId = request.ProductCategoryId,
                    ProductCategoryStatus = request.ProductCategoryStatus
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ProductCategorySearchByItem/{q}", async (string q, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ProductCategoryBySearchItemQuery { Q = q.ToLower() });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ChangeState", async ([FromBody] ChangeStateProductCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStateProductCommand
                {
                    ProductId = request.ProductId,
                    Status = request.Status
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateProductCategoryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateProductCategoryCommand
                {
                    Order = request.Order,
                    ProductCategoryName = request.ProductCategoryName,
                    Description = request.Description,
                    Icon = request.Icon,
                    BusinessId = request.BusinessId
                });
                return result == null ? Results.BadRequest(result) : Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateProductCategoryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateProductCategoryCommand
                {
                    ProductCategoryId = request.ProductCategoryId,
                    Order = request.Order,
                    ProductCategoryName = request.ProductCategoryName,
                    Description = request.Description,
                    Icon = request.Icon,
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete/{ProductCategoryId}", async (Ulid productCategoryId, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new DeleteProductCategoryCommand { ProductCategoryId = productCategoryId }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
    }
}
