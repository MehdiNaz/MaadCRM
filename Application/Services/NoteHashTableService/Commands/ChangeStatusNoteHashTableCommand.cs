namespace Application.Services.NoteHashTableService.Commands;

public struct ChangeStatusNoteHashTableCommand : IRequest<NoteHashTable>
{
    public Ulid Id { get; set; }
    public Status NoteHashTagStatus { get; set; }
}