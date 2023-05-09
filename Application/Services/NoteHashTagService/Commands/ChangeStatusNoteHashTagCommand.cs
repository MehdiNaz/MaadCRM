namespace Application.Services.NoteHashTagService.Commands;

public struct ChangeStatusNoteHashTagCommand : IRequest<CustomerNoteHashTag?>
{
    public Ulid Id { get; set; }
    public StatusType NoteHashTagStatusType { get; set; }
}