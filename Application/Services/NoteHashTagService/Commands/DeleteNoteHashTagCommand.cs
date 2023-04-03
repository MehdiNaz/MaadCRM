namespace Application.Services.NoteHashTagService.Commands;

public struct DeleteNoteHashTagCommand : IRequest<NoteHashTag>
{
    public Ulid NoteHashTagId { get; set; }
}