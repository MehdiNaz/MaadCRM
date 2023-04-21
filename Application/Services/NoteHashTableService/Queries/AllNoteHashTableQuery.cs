namespace Application.Services.NoteHashTableService.Queries;

public struct AllNoteHashTableQuery : IRequest<ICollection<CustomerNoteHashTable>>
{
    public Ulid BusinessId { get; set; }
}