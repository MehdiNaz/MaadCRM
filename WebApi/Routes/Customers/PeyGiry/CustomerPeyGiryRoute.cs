namespace WebApi.Routes.Customers.PeyGiry;

public static class CustomerPeyGiryRoute
{
    public static void MapCustomerPeyGiryRoute(this IEndpointRouteBuilder app)
    {
        #region Customer Pey Giry

        var plan = app.MapGroup("v1/CustomerPeyGiry")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapPost("/AllCustomerPeyGiries/{customerId}", async (Ulid customerId, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomerPeyGiriesQuery
                {
                    CustomerId = customerId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ById", async ([FromBody] CustomerPeyGiryByIdQuery request, IMediator mediator) =>
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
        
        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomerPeyGiryCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusCustomerPeyGiryCommand
                {
                    CustomerPeyGiryId = request.CustomerPeyGiryId,
                    CustomerPeyGiryStatus = request.CustomerPeyGiryStatus
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