namespace Application.Services.NoteHashTableService.Queries;

public struct AllNoteHashTableQuery : IRequest<Result<ICollection<CustomerNoteHashTable>>>
{
    public Ulid BusinessId { get; set; }
}