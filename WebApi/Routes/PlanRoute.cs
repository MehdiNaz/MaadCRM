using Application.Requests;

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

        plan.MapGet("/addPlan", async ([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Disallow)] RequestPlan request) =>
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

    
