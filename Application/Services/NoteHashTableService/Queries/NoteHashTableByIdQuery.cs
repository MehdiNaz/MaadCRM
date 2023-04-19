namespace Application.Services.NoteHashTableService.Queries;

public struct NoteHashTableByIdQuery : IRequest<NoteHashTable>
{
    public Ulid Id { get; set; }
}