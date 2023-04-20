namespace Application.Interfaces.Customers.Notes;

public interface INoteAttachmentRepository
{
    ValueTask<ICollection<NoteAttachment?>> GetAllNoteAttachmentsAsync();
    ValueTask<NoteAttachment?> GetNoteAttachmentByIdAsync(Ulid noteAttachmentId);
    ValueTask<NoteAttachment?> ChangeStatusNoteAttachmentByIdAsync(ChangeStatusNoteAttachmentCommand request);
    ValueTask<NoteAttachment?> CreateNoteAttachmentAsync(CreateNoteAttachmentCommand request);
    ValueTask<NoteAttachment?> UpdateNoteAttachmentAsync(UpdateNoteAttachmentCommand request);
    ValueTask<NoteAttachment?> DeleteNoteAttachmentAsync(DeleteNoteAttachmentCommand request);
}