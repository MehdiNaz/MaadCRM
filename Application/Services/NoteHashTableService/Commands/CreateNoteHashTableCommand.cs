namespace Application.Services.NoteHashTableService.Commands;

public struct CreateNoteHashTableCommand : IRequest<CustomerNoteHashTable>
{
    public string Title { get; set; }
    public Ulid BusinessId { get; set; }
}