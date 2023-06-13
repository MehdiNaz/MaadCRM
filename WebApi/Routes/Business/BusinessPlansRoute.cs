namespace WebApi.Routes.Business;

public static class BusinessPlansRoute
{
    
    public static RouteGroupBuilder MapBusinessPlanRout(this RouteGroupBuilder plan)
    {
        plan.MapGet("/AllBusinessByBusinessId/{businessId}", async (Ulid businessId, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllBusinessPlansQuery
                {
                    BusinessId = businessId
                });
                return result.Match(
                    r => Results.Ok(new
                    {
                        Valid = r,
                        Message = "Show All Business Plans By Business Id",
                    }),
                    exception => Results.BadRequest(new
                    {
                        Valid = false,
                        Message = exception,
                    }));
            }
            catch (Exception e)
            {
                return Results.BadRequest(new
                {
                    Valid = false,
                    e.Message,
                    e.StackTrace
                });
            }
        });

        plan.MapPost("/AllActives/{businessId}", async (Ulid businessId, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllActivePlansQuery()
                {
                    BusinessId = businessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/TheLatest", async ([FromBody] TheLatestPlanQuery request, IMediator mediator) =>
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

        plan.MapPost("/ById", async ([FromBody] BusinessPlansByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new BusinessPlansByIdQuery
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

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusBusinessPlansQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusBusinessPlansQuery
                {
                    StatusType = request.StatusType,
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

        plan.MapDelete("/Delete/{Id}", async (Ulid Id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteBusinessPlansCommand
                {
                    BusinessPlansId = Id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        return plan;
    }
}
