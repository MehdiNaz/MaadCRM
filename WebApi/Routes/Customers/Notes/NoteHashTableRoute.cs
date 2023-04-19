namespace WebApi.Routes.Customers.Notes;

public static class NoteHashTableRoute
{
    public static void MapNoteHashTableRoute(this IEndpointRouteBuilder app)
    {
        #region NoteHashTable

        var plan = app.MapGroup("v1/NoteHashTable")
            //.RequireAuthorization()
            .EnableOpenApiWithAuthentication()
            .WithOpenApi();

        plan.MapPost("/AllNoteHashTables", async ([FromBody] AllNoteHashTableQuery request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new AllNoteHashTableQuery
                {
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapGet("/ById/{noteHashTable}", async (Ulid noteHashTable, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new NoteHashTableByIdQuery { Id = noteHashTable }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/Insert", async ([FromBody] CreateNoteHashTableCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new CreateNoteHashTableCommand
                {
                    Title = request.Title,
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPost("/ChangeStatus", async ([FromBody] ChangeNoteHashTableCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new ChangeNoteHashTableCommand
                {
                    Id = request.Id,
                    NoteHashTagStatus = request.NoteHashTagStatus
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapPut("/Update", async ([FromBody] UpdateNoteHashTableCommand request, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.Send(new UpdateNoteHashTableCommand
                {
                    Id = request.Id,
                    Title = request.Title,
                    BusinessId = request.BusinessId
                });
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });

        plan.MapDelete("/Delete", async ([FromBody] DeleteNoteHashTableCommand request, IMediator mediator) =>
        {
            try
            {
                return Results.Ok(await mediator.Send(new DeleteNoteHashTableCommand { Id = request.Id }));
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.ParamName);
            }
        });
        #endregion
    }
}