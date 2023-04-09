namespace Application.Services.NoteHashTagService.Queries;

public struct NoteHashTagByIdQuery : IRequest<NoteHashTag>
{
    public Ulid NoteHashTagId { get; set; }
}