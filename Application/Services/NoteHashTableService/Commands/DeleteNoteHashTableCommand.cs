namespace Application.Services.NoteHashTableService.Commands;

public struct DeleteNoteHashTableCommand : IRequest<Result<CustomerNoteHashTableResponse>>
{
    public Ulid Id { get; set; }
}