namespace Application.Services.NoteHashTableService.Queries;

public struct NoteHashTableByIdQuery : IRequest<Result<CustomerNoteHashTable>>
{
    public Ulid Id { get; set; }
}