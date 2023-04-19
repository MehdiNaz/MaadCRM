namespace WebApi.Routes.Customers.Notes;

public static class NoteHashTagRoute
{
    public static void MapNoteHashTagRoute(this IEndpointRouteBuilder app)
    {
        #region BusinessPlans

        var plan = app.MapGroup("v1/NoteHashTag")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapPost("/AllNoteHashTags", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllNoteHashTagQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ById", async ([FromBody] NoteHashTagByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new NoteHashTagByIdQuery
                {
                    NoteHashTagId = request.NoteHashTagId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateNoteHashTagCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateNoteHashTagCommand
                {
                    // Title = request.Title,
                    CustomerNoteId = request.CustomerNoteId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusNoteHashTagCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusNoteHashTagCommand
                {
                    NoteHashTagStatus = request.NoteHashTagStatus,
                    NoteHashTagId = request.NoteHashTagId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateNoteHashTagCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateNoteHashTagCommand
                {
                    NoteHashTagId = request.NoteHashTagId,
                    // Title = request.Title,
                    CustomerNoteId = request.CustomerNoteId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteNoteHashTagCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteNoteHashTagCommand
                {
                    NoteHashTagId = request.NoteHashTagId
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