namespace WebApi.Routes;

public static class BusinessPlansRoute
{
    public static void MapBusinessPlanRout(this IEndpointRouteBuilder app)
    {
        #region Account

        var plan = app.MapGroup("v1/BusinessPlan")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllBusinessByBusinessId", async ([FromBody] AllBusinessPlansQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllBusinessPlansQuery
                {
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/AllActives", async ([FromBody] AllActivePlansQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllActivePlansQuery()
                {
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/TheLatest", async ([FromBody] TheLatestPlanQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new TheLatestPlanQuery()
                {
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById", async ([FromBody] BusinessPlansByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new BusinessPlansByIdQuery()
                {
                    BusinessPlansId = request.BusinessPlansId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ChangeStatus", async ([FromBody] ChangeStatusBusinessPlansQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusBusinessPlansQuery
                {
                    Status = request.Status,
                    BusinessPlansId = request.BusinessPlansId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateBusinessPlansCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateBusinessPlansCommand
                {
                    PlanId = request.PlanId,
                    CountOfDay = request.CountOfDay,
                    CountOfUsers = request.CountOfUsers,
                    BusinessId = request.BusinessId,
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateBusinessPlansCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateBusinessPlansCommand
                {
                    BusinessPlansId = request.BusinessPlansId,
                    PlanId = request.PlanId,
                    CountOfDay = request.CountOfDay,
                    CountOfUsers = request.CountOfUsers,
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteBusinessPlansCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteBusinessPlansCommand
                {
                    BusinessPlansId = request.BusinessPlansId,
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
