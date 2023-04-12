namespace Application.Services.NoteHashTagService.Commands;

public struct ChangeStatusNoteHashTagCommand : IRequest<NoteHashTag?>
{
    public Ulid NoteHashTagId { get; set; }
    public Status NoteHashTagStatus { get; set; }
}