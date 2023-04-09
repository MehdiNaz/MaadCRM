namespace Application.Interfaces.Customers.Notes;

public interface INoteAttachmentRepository
{
    ValueTask<ICollection<NoteAttachment?>> GetAllNoteAttachmentsAsync();
    ValueTask<NoteAttachment?> GetNoteAttachmentByIdAsync(Ulid noteAttachmentId);
    ValueTask<NoteAttachment?> CreateNoteAttachmentAsync(NoteAttachment? entity);
    ValueTask<NoteAttachment?> UpdateNoteAttachmentAsync(NoteAttachment entity);
    ValueTask<NoteAttachment?> DeleteNoteAttachmentAsync(Ulid noteAttachmentId);
}