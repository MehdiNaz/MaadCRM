namespace Application.Services.NoteHashTableService.Commands;

public struct CreateNoteHashTableCommand : IRequest<Result<CustomerNoteHashTableResponse>>
{
    public string Title { get; set; }
    public Ulid BusinessId { get; set; }
}