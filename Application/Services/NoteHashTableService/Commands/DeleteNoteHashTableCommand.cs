namespace Application.Services.NoteHashTableService.Commands;

public struct DeleteNoteHashTableCommand : IRequest<CustomerNoteHashTable>
{
    public Ulid Id { get; set; }
}