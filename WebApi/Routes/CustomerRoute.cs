using Domain.Models.Address;
using Domain.Models.Customers;
using Domain.Models.Customers.Notes;

namespace WebApi.Routes;

public static class CustomerRoute
{
    public static void MapCustomerRoute(this IEndpointRouteBuilder app)
    {
        #region Customer

        var plan = app.MapGroup("v1/Customer")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllCustomers", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomersQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById", async ([FromBody] CustomerByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerByIdQuery
                {
                    CustomerId = request.CustomerId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateCustomerCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomerCommand
                {
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

        plan.MapPut("/Update", async ([FromBody] UpdateCustomerCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomerCommand
                {
                    CustomerId = request.CustomerId,
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
                    City = request.City
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteCustomerCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomerCommand
                {
                    CustomerId = request.CustomerId,
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