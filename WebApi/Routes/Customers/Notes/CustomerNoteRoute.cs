namespace WebApi.Routes.Customers.Notes;

public static class CustomerNoteRoute
{
    public static void MapCustomerNoteRoute(this IEndpointRouteBuilder app)
    {
        #region CustomerNote

        var plan = app.MapGroup("v1/CustomerNote")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllCustomersNote", async ([FromBody] AllCustomerNotesQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomerNotesQuery
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

        plan.MapGet("/ById/{customerNoteId}", async (Ulid customerNoteId, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new CustomerNoteByIdQuery { CustomerNoteId = customerNoteId }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateCustomerNoteCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomerNoteCommand
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

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomerNoteCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusCustomerNoteCommand
                {
                    CustomerNoteStatus = request.CustomerNoteStatus,
                    CustomerNoteId = request.CustomerNoteId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateCustomerNoteCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomerNoteCommand
                {
                    CustomerNoteId = request.CustomerNoteId,
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

        plan.MapDelete("/Delete", async ([FromBody] DeleteCustomerNoteCommand request, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new DeleteCustomerNoteCommand { CustomerNoteId = request.CustomerNoteId }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        #endregion
    }
}