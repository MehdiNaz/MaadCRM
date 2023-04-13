namespace WebApi.Routes.Customers;

public static class CustomerFeedbackRoute
{
    public static void MapCustomerFeedbackRoute(this IEndpointRouteBuilder app)
    {
        #region Customer

        var plan = app.MapGroup("v1/CustomerFeedback")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllCustomerFeedbacks", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllCustomerFeedBackQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById", async ([FromBody] CustomerFeedBackByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CustomerFeedBackByIdQuery
                {
                    //CustomersAddressId = request.CustomersAddressId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateCustomerFeedBackCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateCustomerFeedBackCommand
                {
                    //Address = request.Address,
                    //CodePost = request.CodePost,
                    //PhoneNo = request.PhoneNo,
                    //Description = request.Description,
                    //Id = request.Id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusCustomerFeedBackCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusCustomerFeedBackCommand
                {
                    //Address = request.Address,
                    //CodePost = request.CodePost,
                    //PhoneNo = request.PhoneNo,
                    //Description = request.Description,
                    //Id = request.Id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateCustomerFeedBackCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateCustomerFeedBackCommand
                {
                    //CustomersAddressId = request.CustomersAddressId,
                    //Address = request.Address,
                    //CodePost = request.CodePost,
                    //PhoneNo = request.PhoneNo,
                    //Description = request.Description,
                    //Id = request.Id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteCustomerFeedBackCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteCustomerFeedBackCommand
                {
                    // CustomersAddressId = request.CustomersAddressId,
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