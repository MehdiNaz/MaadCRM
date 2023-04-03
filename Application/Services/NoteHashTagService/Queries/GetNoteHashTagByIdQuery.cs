namespace Application.Services.NoteHashTagService.Queries;

public struct GetNoteHashTagByIdQuery : IRequest<NoteHashTag>
{
    public Ulid NoteHashTagId { get; set; }
}