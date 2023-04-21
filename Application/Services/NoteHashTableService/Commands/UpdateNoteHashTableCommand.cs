namespace Application.Services.NoteHashTableService.Commands;

public struct UpdateNoteHashTableCommand : IRequest<CustomerNoteHashTable>
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public Ulid BusinessId { get; set; }
}