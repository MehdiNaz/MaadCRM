namespace WebApi.Routes.Customers.Notes;

public static class NoteAttachmentRoute
{
    public static RouteGroupBuilder MapNoteAttachmentRoute(this RouteGroupBuilder noteAttachment)
    {
        noteAttachment.MapPost("/AllNoteAttachments", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllNoteAttachmentQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        noteAttachment.MapGet("/ById/{noteAttachmentId}", async (Ulid noteAttachmentId, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new NoteAttachmentByIdQuery
                {
                    NoteAttachmentId = noteAttachmentId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        noteAttachment.MapPost("/Insert", async ([FromBody] CreateNoteAttachmentCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateNoteAttachmentCommand
                {
                    CustomerNoteId = request.CustomerNoteId,
                    FileName = request.FileName,
                    Extenstion = request.Extenstion
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        noteAttachment.MapPost("/ChangeStatus", async ([FromBody] ChangeStatusNoteAttachmentCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeStatusNoteAttachmentCommand
                {
                    NoteAttachmentStatusType = request.NoteAttachmentStatusType,
                    Id = request.Id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        noteAttachment.MapPut("/Update", async ([FromBody] UpdateNoteAttachmentCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateNoteAttachmentCommand
                {
                    Id = request.CustomerNoteId,
                    CustomerNoteId = request.CustomerNoteId,
                    FileName = request.FileName,
                    Extenstion = request.Extenstion
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        noteAttachment.MapDelete("/Delete/{idAttachment}", async (Ulid idAttachment, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteNoteAttachmentCommand
                {
                    Id = idAttachment
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
        
        return noteAttachment;
    }
}