namespace WebApi.Routes.Customers;

public static class CustomerAddressRoute
{
    public static void MapCustomerAddressRoute(this IEndpointRouteBuilder app)
    {
        #region Customer Address

        var plan = app.MapGroup("v1/CustomerAddress")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapPost("/AllCustomerAddress/{id}", async (Ulid id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomerAddressQuery
                {
                    CustomerId = id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById/{customersAddressId}", async (Ulid customersAddressId, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new CustomerAddressByIdQuery { CustomersAddressId = customersAddressId }));
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

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomersAddressCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusCustomersAddressCommand
                {
                    Id = request.Id,
                    CustomersAddressStatus = request.CustomersAddressStatus
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
                    Id = request.Id,
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

        plan.MapDelete("/Delete/{customersAddressId}", async (Ulid customersAddressId, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new DeleteCustomersAddressCommand { Id = customersAddressId }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        #endregion
    }
}