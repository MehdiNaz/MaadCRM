namespace WebApi.Routes.Customers.Notes;

public static class NoteHashTagRoute
{
    //  // 
    public static RouteGroupBuilder MapNoteHashTagRoute(this RouteGroupBuilder noteHashTag)
    {
        noteHashTag.MapPost("/AllNoteHashTags", async (IMediator mediator) =>
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

        noteHashTag.MapGet("/ById/{noteHashTagId}", async (Ulid noteHashTagId, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new NoteHashTagByIdQuery
                {
                    NoteHashTagId = noteHashTagId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        noteHashTag.MapPost("/Insert", async ([FromBody] CreateNoteHashTagCommand request, IMediator mediator) =>
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

        noteHashTag.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusNoteHashTagCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusNoteHashTagCommand
                {
                    NoteHashTagStatusType = request.NoteHashTagStatusType,
                    Id = request.Id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        noteHashTag.MapPut("/Update", async ([FromBody] UpdateNoteHashTagCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateNoteHashTagCommand
                {
                    CustomerNoteId = request.CustomerNoteId,
                    NoteHashTableId = request.NoteHashTableId
                });
                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        noteHashTag.MapDelete("/Delete/{Id}", async (Ulid Id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteNoteHashTagCommand
                {
                    Id = Id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        return noteHashTag;
    }
}