namespace Application.Services.NoteHashTableService.Queries;

public struct AllNoteHashTableQuery : IRequest<ICollection<NoteHashTable>>
{
    public Ulid BusinessId { get; set; }
}