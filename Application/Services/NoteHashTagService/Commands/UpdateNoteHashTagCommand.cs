namespace Application.Services.NoteHashTagService.Commands;

public struct UpdateNoteHashTagCommand : IRequest<NoteHashTag>
{
    public Ulid NoteHashTagId { get; set; }
    // public string Title { get; set; }
    public Ulid CustomerNoteId { get; set; }
}