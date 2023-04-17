namespace WebApi.Routes.Customers;

public static class CustomerRoute
{
    public static void MapCustomerRoute(this IEndpointRouteBuilder app)
    {
        #region Customer

        var plan = app.MapGroup("v1/Customer")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
        .WithOpenApi();

        plan.MapGet("/AllCustomers", async ([FromBody] AllCustomersQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomersQuery
                {
                    UserId = request.UserId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById/{customerId}", async (Ulid customerId, IMediator mediator) =>
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

        plan.MapPost("/Insert", async ([FromBody] CreateCustomerCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomerCommand
                {
                    UserId = request.UserId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDayDate = request.BirthDayDate!,
                    CustomerPic = request.CustomerPic,
                    CustomerCategoryId = request.CustomerCategoryId,
                    Gender = request.Gender,
                    CustomerMoarefId = request.CustomerMoarefId,
                    PhoneNumbers = request.PhoneNumbers,
                    EmailAddresses = request.EmailAddresses,
                    FavoritesLists = request.FavoritesLists,
                    CustomersAddresses = request.CustomersAddresses,
                    CustomerNotes = request.CustomerNotes,
                    CustomerPeyGiries = request.CustomerPeyGiries,
                    CityId = request.CityId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
        
        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomerCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusCustomerCommand
                {
                    CustomerStatus = request.CustomerStatus,
                    CustomerId = request.CustomerId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateCustomerCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomerCommand
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDayDate = request.BirthDayDate,
                    CustomerPic = request.CustomerPic,
                    CustomerCategoryId = request.CustomerCategoryId,
                    Gender = request.Gender,
                    CustomerMoarefId = request.CustomerMoarefId,
                    PhoneNumbers = request.PhoneNumbers,
                    EmailAddresses = request.EmailAddresses,
                    FavoritesLists = request.FavoritesLists,
                    CustomersAddresses = request.CustomersAddresses,
                    CustomerNotes = request.CustomerNotes,
                    CustomerPeyGiries = request.CustomerPeyGiries,
                    CityId = request.CityId
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
                var result = await mediator.Send(new DeleteCustomerCommand
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
        #endregion
    }
}