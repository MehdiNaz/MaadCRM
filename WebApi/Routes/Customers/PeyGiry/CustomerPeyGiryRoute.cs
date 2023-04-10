namespace WebApi.Routes.Customers.PeyGiry;

public static class CustomerPeyGiryRoute
{
    public static void MapCustomerPeyGiryRoute(this IEndpointRouteBuilder app)
    {
        #region Customer

        var plan = app.MapGroup("v1/CustomerPeyGiry")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllCustomerPeyGiries", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomerPeyGiriesQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById", async ([FromBody] CustomerPeyGiryByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerPeyGiryByIdQuery
                {
                    CustomerPeyGiryId = request.CustomerPeyGiryId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateCustomerPeyGiryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomerPeyGiryCommand
                {
                    Description = request.Description,
                    CustomerId = request.CustomerId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateCustomerPeyGiryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomerPeyGiryCommand
                {
                    CustomerPeyGiryId = request.CustomerPeyGiryId,
                    Description = request.Description,
                    CustomerId = request.CustomerId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteCustomerPeyGiryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomerPeyGiryCommand
                {
                    CustomerPeyGiryId = request.CustomerPeyGiryId
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