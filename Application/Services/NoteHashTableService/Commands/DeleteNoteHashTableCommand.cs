namespace Application.Services.NoteHashTableService.Commands;

public struct DeleteNoteHashTableCommand : IRequest<NoteHashTable>
{
    public Ulid Id { get; set; }
}