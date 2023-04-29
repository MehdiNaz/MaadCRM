namespace Application.Services.NoteHashTableService.Queries;

public struct NoteHashTableByIdQuery : IRequest<Result<CustomerNoteHashTableResponse>>
{
    public Ulid Id { get; set; }
}