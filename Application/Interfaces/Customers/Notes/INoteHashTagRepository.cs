namespace Application.Interfaces.Customers.Notes;

public interface INoteHashTagRepository
{
    ValueTask<ICollection<NoteHashTag?>> GetAllNoteHashTagsAsync();
    ValueTask<NoteHashTag?> GetNoteHashTagByIdAsync(Ulid noteHashTagId);
    ValueTask<NoteHashTag?> CreateNoteHashTagAsync(NoteHashTag? entity);
    ValueTask<NoteHashTag?> UpdateNoteHashTagAsync(NoteHashTag entity);
    ValueTask<NoteHashTag?> DeleteNoteHashTagAsync(Ulid noteHashTagId);
}