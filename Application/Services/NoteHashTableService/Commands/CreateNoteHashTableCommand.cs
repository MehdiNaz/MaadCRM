namespace Application.Services.NoteHashTableService.Commands;

public struct CreateNoteHashTableCommand : IRequest<NoteHashTable>
{
    public string Title { get; set; }
    public Ulid BusinessId { get; set; }
}