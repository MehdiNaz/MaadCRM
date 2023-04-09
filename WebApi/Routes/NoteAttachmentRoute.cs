namespace WebApi.Routes;

public static class NoteAttachmentRoute
{
    public static void MapNoteAttachmentRoute(this IEndpointRouteBuilder app)
    {
        #region BusinessPlans

        var plan = app.MapGroup("v1/NoteAttachment")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllNoteAttachments", async (IMediator mediator) =>
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

        plan.MapGet("/ById", async ([FromBody] NoteAttachmentByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new NoteAttachmentByIdQuery
                {
                    NoteAttachmentId = request.NoteAttachmentId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateNoteAttachmentCommand request, IMediator mediator) =>
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

        plan.MapPut("/Update", async ([FromBody] UpdateNoteAttachmentCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateNoteAttachmentCommand
                {
                    NoteAttachmentId = request.CustomerNoteId,
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

        plan.MapDelete("/Delete", async ([FromBody] DeleteNoteAttachmentCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeleteNoteAttachmentCommand
                {
                    NoteAttachmentId = request.NoteAttachmentId,
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