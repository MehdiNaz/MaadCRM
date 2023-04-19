namespace WebApi.Routes.Products;

public static class ProductRoute
{
    public static void MapProductRoute(this IEndpointRouteBuilder app)
    {
        var plan = app.MapGroup("v1/Product")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllProducts/{businessId}", async (Ulid businessId, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new AllProductsQuery { BusinessId = businessId }));
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        plan.MapPost("/ById/{customerId}", async (Ulid customerId, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new CustomerByIdQuery { CustomerId = customerId }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusProductByIdCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusProductByIdCommand
                {
                    ProductId = request.ProductId,
                    ProductStatus = request.ProductStatus
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ProductBySearchItem/{q}", async (string q, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ProductBySearchItemQuery { Q = q.ToLower() });
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

        plan.MapPost("/Insert", async ([FromBody] CreateProductCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateProductCommand
                {
                    ProductName = request.ProductName,
                    ProductCategoryId = request.ProductCategoryId,
                    Title = request.Title,
                    Summery = request.Summery,
                    Price = request.Price,
                    SecondaryPrice = request.SecondaryPrice,
                    Discount = request.Discount,
                    DiscountPercent = request.DiscountPercent,
                    FavoritesListId = request.FavoritesListId,
                    Picture = request.Picture
                });
                return result == null ? Results.BadRequest(result) : Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateProductCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateProductCommand
                {
                    ProductId = request.ProductId,
                    ProductName = request.ProductName,
                    ProductCategoryId = request.ProductCategoryId,
                    Title = request.Title,
                    Summery = request.Summery,
                    Price = request.Price,
                    SecondaryPrice = request.SecondaryPrice,
                    Discount = request.Discount,
                    DiscountPercent = request.DiscountPercent,
                    FavoritesListId = request.FavoritesListId,
                    Picture = request.Picture
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete/{customerId}", async (Ulid customerId, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new DeleteProductCommand { ProductId = customerId }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
    }
}
