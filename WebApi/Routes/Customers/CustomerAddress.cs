namespace WebApi.Routes.Customers;

public static class CustomerAddressRoute
{
    public static void MapCustomerAddressRoute(this IEndpointRouteBuilder app)
    {
        #region Customer

        var plan = app.MapGroup("v1/CustomerAddress")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllCustomerAddress", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomerAddressQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById", async ([FromBody] CustomerAddressByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerAddressByIdQuery
                {
                    CustomersAddressId = request.CustomersAddressId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateCustomersAddressCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomersAddressCommand
                {
                    Address = request.Address,
                    CodePost = request.CodePost,
                    PhoneNo = request.PhoneNo,
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

        plan.MapPut("/Update", async ([FromBody] UpdateCustomersAddressCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomersAddressCommand
                {
                    CustomersAddressId = request.CustomersAddressId,
                    Address = request.Address,
                    CodePost = request.CodePost,
                    PhoneNo = request.PhoneNo,
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

        plan.MapDelete("/Delete", async ([FromBody] DeleteCustomersAddressCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomersAddressCommand
                {
                    CustomersAddressId = request.CustomersAddressId,
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