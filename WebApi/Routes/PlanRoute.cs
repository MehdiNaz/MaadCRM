namespace WebApi.Routes;

public static class PlanRoute
{
    public static void MapPlanRoute(this IEndpointRouteBuilder app)
    {
        #region Account

        var plan = app.MapGroup("v1/plan")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllPlans", async (IMediator mediator) =>
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

        plan.MapGet("/PlanById", async ([FromBody] PlanByIdQuery request, IMediator mediator) =>
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

        plan.MapPost("/InsertPlan", async ([FromBody] CreatePlanCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreatePlanCommand
                {
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

        plan.MapPut("/UpdatePlan", async ([FromBody] UpdatePlanCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdatePlanCommand
                {
                    Id = request.Id,
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
        
        plan.MapDelete("/DeletePlan", async ([FromBody] DeletePlanCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeletePlanCommand
                {
                    PlanId = request.PlanId,
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
