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

        plan.MapPost("/ById", async ([FromBody] PeyGiryAttachmentByIdQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new PeyGiryAttachmentByIdQuery
                {
                    PeyGiryAttachmentId = request.PeyGiryAttachmentId
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
                    PeyGiryAttachmentId = request.PeyGiryAttachmentId,
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

        plan.MapDelete("/Delete", async ([FromBody] DeletePeyGiryAttachmentCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new DeletePeyGiryAttachmentCommand
                {
                    PeyGiryAttachmentId = request.PeyGiryAttachmentId
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