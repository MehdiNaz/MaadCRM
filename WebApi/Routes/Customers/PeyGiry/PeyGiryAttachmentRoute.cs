namespace WebApi.Routes.Customers.PeyGiry;

public static class PeyGiryAttachmentRoute
{
    public static void MapCustomerPeyGiryAttachmentRoute(this IEndpointRouteBuilder app)
    {
        #region CustomerPeyGiryAttachment

        var plan = app.MapGroup("v1/PeyGiryAttachment")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapGet("/AllPeyGiryAttachments", async (IMediator mediator) =>
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

        plan.MapGet("/ById/{peyGiryAttachmentId}", async (Ulid peyGiryAttachmentId, IMediator mediator) =>
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

        plan.MapPost("/Insert", async ([FromBody] CreatePeyGiryAttachmentCommand request, IMediator mediator) =>
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

        plan.MapPut("/Update", async ([FromBody] UpdatePeyGiryAttachmentCommand request, IMediator mediator) =>
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

        plan.MapDelete("/Delete/{Id}", async (Ulid Id, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeletePeyGiryAttachmentCommand
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


        #endregion
    }
}