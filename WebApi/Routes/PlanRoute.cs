namespace WebApi.Routes;

public static class PlanRoute
{
    public static void MapPlanRoute(this IEndpointRouteBuilder app)
    {
        #region Plan

        var plan = app.MapGroup("v1/plan")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapPost("/AllPlans", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllPlansQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ById", async ([FromBody] PlanByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new PlanByIdQuery
                {
                    PlanId = request.PlanId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreatePlanCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreatePlanCommand
                {
                    UserId = request.UserId,
                    PriceOfDay = request.PriceOfDay,
                    CountOfDay = request.CountOfDay,
                    CountOfUsers = request.CountOfUsers,
                    PlanName = request.PlanName,
                    PriceOfUsers = request.PriceOfUsers
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusPlanCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusPlanCommand
                {
                    PlanId = request.PlanId,
                    PlanStatus = request.PlanStatus
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdatePlanCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdatePlanCommand
                {
                    Id = request.Id,
                    UserId = request.UserId,
                    PriceOfDay = request.PriceOfDay,
                    CountOfDay = request.CountOfDay,
                    CountOfUsers = request.CountOfUsers,
                    PlanName = request.PlanName,
                    PriceOfUsers = request.PriceOfUsers,
                    FinalPrice = request.FinalPrice
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeletePlanCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeletePlanCommand
                {
                    Id = request.Id,
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
