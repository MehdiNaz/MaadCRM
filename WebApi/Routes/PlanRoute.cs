namespace WebApi.Routes;

public static class PlanRoute
{
    public static void MapPlanRoute(this IEndpointRouteBuilder app)
    {
        #region Account

        var plan = app.MapGroup("v1/plan")
            .RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/InsertPlan", async ([FromBody] CreatePlanCommand request, IMediator mediator) =>
        {
            try
            {
                //var result = mediator.Send(new CreatePlanCommand());
                return Results.Ok(null);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/addPlan", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] CreatePlanCommand request) =>
        {
            try
            {
                return Results.Ok("Add Plan ");
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        #endregion
    }
}


