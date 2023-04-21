namespace Application.Services.NoteHashTagService.Queries;

public struct NoteHashTagByIdQuery : IRequest<CustomerNoteHashTag>
{
    public Ulid NoteHashTagId { get; set; }
}