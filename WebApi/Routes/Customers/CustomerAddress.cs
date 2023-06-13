namespace WebApi.Routes.Customers;

public static class CustomerAddressRoute
{
    public static RouteGroupBuilder MapCustomerAddressRoute(this RouteGroupBuilder customerAddress)
    {

        customerAddress.MapGet("/AllCustomerAddress/{id}", async (Ulid id, IMediator mediator) =>
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

        customerAddress.MapGet("/ById/{customersAddressId}", async (Ulid customersAddressId, IMediator mediator) =>
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

        customerAddress.MapPost("/Insert", async ([FromBody] CreateCustomersAddressCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomersAddressCommand
                {
                    Address = request.Address,
                    CodePost = request.CodePost,
                    PhoneNo = request.PhoneNo,
                    Description = request.Description,
                    CustomerId = request.CustomerId,


                    // TODO: Get From Token
                    IdUser = request.IdUser
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        customerAddress.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomersAddressCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusCustomersAddressCommand
                {
                    Id = request.Id,
                    CustomersAddressStatusType = request.CustomersAddressStatusType
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        customerAddress.MapPut("/Update", async ([FromBody] UpdateCustomersAddressCommand request, IMediator mediator) =>
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
                    CustomerId = request.CustomerId,

                    // TODO: Get From Token
                    IdUser = request.IdUser
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        customerAddress.MapDelete("/Delete/{customersAddressId}", async (Ulid customersAddressId, IMediator mediator) =>
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
        
        return customerAddress;
    }
}