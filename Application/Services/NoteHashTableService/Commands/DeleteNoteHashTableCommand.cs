namespace Application.Services.NoteHashTableService.Commands;

public struct DeleteNoteHashTableCommand : IRequest<Result<CustomerNoteHashTable>>
{
    public Ulid Id { get; set; }
}