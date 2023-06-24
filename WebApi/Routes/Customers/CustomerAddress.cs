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

        customerAddress.MapPost("/Insert", async ([FromBody] CreateCustomersAddressCommand request, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var authHeader = httpContext.Request.Headers["Authorization"].ToString();
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = authHeader,
                    ReturnType = TokenReturnType.UserId
                });
            
                return id.Result.Match(
                    idUser =>
                    {
                        var resultAddress = mediator.Send(request with
                        {
                            IdUser = idUser
                        });

                        return Results.Ok(resultAddress);
                    },
                    exception => Results.BadRequest(new ErrorResponse
                    {
                        Valid = false,
                        Exceptions = exception
                    }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Valid = false,
                    Exceptions = e
                });
            }
        });

        customerAddress.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomersAddressCommand request, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var authHeader = httpContext.Request.Headers["Authorization"].ToString();
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = authHeader,
                    ReturnType = TokenReturnType.UserId
                });
            
                return id.Result.Match(
                    idUser =>
                    {
                        var resultAddress = mediator.Send(request with
                        {
                            IdUser = idUser
                        });

                        return Results.Ok(resultAddress);
                    },
                    exception => Results.BadRequest(new ErrorResponse
                    {
                        Valid = false,
                        Exceptions = exception
                    }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Valid = false,
                    Exceptions = e
                });
            }
        });

        customerAddress.MapPut("/Update", async ([FromBody] UpdateCustomersAddressCommand request, IMediator mediator, HttpContext httpContext) =>
        {
            try
            {
                var authHeader = httpContext.Request.Headers["Authorization"].ToString();
                var id = mediator.Send(new DecodeTokenQuery
                {
                    Token = authHeader,
                    ReturnType = TokenReturnType.UserId
                });
            
                return id.Result.Match(
                    idUser =>
                    {
                        var resultAddress = mediator.Send(request with
                        {
                            IdUser = idUser
                        });

                        return Results.Ok(resultAddress);
                    },
                    exception => Results.BadRequest(new ErrorResponse
                    {
                        Valid = false,
                        Exceptions = exception
                    }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new ErrorResponse
                {
                    Valid = false,
                    Exceptions = e
                });
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