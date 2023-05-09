namespace Application.Services.NoteHashTableService.Commands;

public struct ChangeStatusNoteHashTableCommand : IRequest<Result<CustomerNoteHashTableResponse>>
{
    public Ulid Id { get; set; }
    public StatusType NoteHashTagStatusType { get; set; }
}