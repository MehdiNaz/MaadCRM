﻿namespace WebApi.Routes.Customers.Notes;

public static class NoteHashTagRoute
{
    public static void MapNoteHashTagRoute(this IEndpointRouteBuilder app)
    {
        #region NoteHashTag

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

        plan.MapGet("/ById/{noteHashTagId}", async (Ulid noteHashTagId, IMediator mediator) =>
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

        plan.MapPut("/Update", async ([FromBody] UpdateNoteHashTagCommand request, IMediator mediator) =>
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

        plan.MapDelete("/Delete/{Id}", async (Ulid Id, IMediator mediator) =>
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

        #endregion
    }
}