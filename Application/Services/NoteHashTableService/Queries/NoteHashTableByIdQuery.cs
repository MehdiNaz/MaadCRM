namespace Application.Services.NoteHashTableService.Queries;

public struct NoteHashTableByIdQuery : IRequest<CustomerNoteHashTable>
{
    public Ulid Id { get; set; }
}