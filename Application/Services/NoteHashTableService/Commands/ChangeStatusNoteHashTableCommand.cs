namespace Application.Services.NoteHashTableService.Commands;

public struct ChangeStatusNoteHashTableCommand : IRequest<Result<CustomerNoteHashTable>>
{
    public Ulid Id { get; set; }
    public Status NoteHashTagStatus { get; set; }
}