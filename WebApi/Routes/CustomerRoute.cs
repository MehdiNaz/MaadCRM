namespace WebApi.Routes;

public static class CustomerRoute
{
    public static void MapCustomerRoute(this IEndpointRouteBuilder app)
    {
        #region Account

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
                    BirthDayDate = request.BirthDayDate,
                    CustomerPic = request.CustomerPic,
                    CreatedBy = request.CreatedBy,
                    UpdatedBy = request.UpdatedBy,
                    UserId = request.UserId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateBusinessCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateBusinessCommand
                {
                    BusinessId = request.BusinessId,
                    BusinessName = request.BusinessName,
                    Url = request.Url,
                    Hosts = request.Hosts,
                    CompanyName = request.CompanyName,
                    CompanyAddress = request.CompanyAddress,
                    DisplayOrder = request.DisplayOrder,
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteBusinessCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteBusinessCommand
                {
                    BusinessId = request.BusinessId,
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