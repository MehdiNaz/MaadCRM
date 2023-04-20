namespace Application.Interfaces.Customers.Notes;

public interface INoteHashTagRepository
{
    ValueTask<ICollection<NoteHashTag?>> GetAllNoteHashTagsAsync();
    ValueTask<NoteHashTag?> GetNoteHashTagByIdAsync(Ulid noteHashTagId);
    ValueTask<NoteHashTag?> ChangeStatusNoteHashTagByIdAsync(ChangeStatusNoteHashTagCommand request);
    ValueTask<NoteHashTag?> CreateNoteHashTagAsync(CreateNoteHashTagCommand request);
    ValueTask<NoteHashTag?> UpdateNoteHashTagAsync(UpdateNoteHashTagCommand request);
    ValueTask<NoteHashTag?> DeleteNoteHashTagAsync(DeleteNoteHashTagCommand request);
}