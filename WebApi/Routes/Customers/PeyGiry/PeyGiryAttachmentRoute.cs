namespace WebApi.Routes.Customers.PeyGiry;

public static class PeyGiryAttachmentRoute
{
    public static RouteGroupBuilder MapCustomerPeyGiryAttachmentRoute(this RouteGroupBuilder customerPeyGiryAttachment)
    {
        customerPeyGiryAttachment.MapGet("/AllPeyGiryAttachments", async (IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllPeyGiryAttachmentQuery());
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        customerPeyGiryAttachment.MapGet("/ById/{peyGiryAttachmentId}", async (Ulid peyGiryAttachmentId, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new PeyGiryAttachmentByIdQuery
                {
                    PeyGiryAttachmentId = peyGiryAttachmentId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        customerPeyGiryAttachment.MapPost("/Insert", async ([FromBody] CreatePeyGiryAttachmentCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreatePeyGiryAttachmentCommand
                {
                    PeyGiryNoteId = request.PeyGiryNoteId,
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

        customerPeyGiryAttachment.MapPut("/Update", async ([FromBody] UpdatePeyGiryAttachmentCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdatePeyGiryAttachmentCommand
                {
                    Id = request.Id,
                    PeyGiryNoteId = request.PeyGiryNoteId,
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

        customerPeyGiryAttachment.MapDelete("/Delete/{id}", async (Ulid id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeletePeyGiryAttachmentCommand
                {
                    Id = id
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
        
        return customerPeyGiryAttachment;
    }
}