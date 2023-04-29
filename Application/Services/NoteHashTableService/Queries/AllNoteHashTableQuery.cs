namespace Application.Services.NoteHashTableService.Queries;

public struct AllNoteHashTableQuery : IRequest<Result<ICollection<CustomerNoteHashTableResponse>>>
{
    public Ulid BusinessId { get; set; }
}