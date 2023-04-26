namespace Application.Interfaces.Customers.Notes;

public interface INoteAttachmentRepository
{
    ValueTask<ICollection<CustomerNoteAttachment?>> GetAllNoteAttachmentsAsync();
    ValueTask<CustomerNoteAttachment?> GetNoteAttachmentByIdAsync(Ulid noteAttachmentId);
    ValueTask<CustomerNoteAttachment?> ChangeStatusNoteAttachmentByIdAsync(ChangeStatusNoteAttachmentCommand request);
    ValueTask<CustomerNoteAttachment?> CreateNoteAttachmentAsync(CreateNoteAttachmentCommand request);
    ValueTask<CustomerNoteAttachment?> UpdateNoteAttachmentAsync(UpdateNoteAttachmentCommand request);
    ValueTask<CustomerNoteAttachment?> DeleteNoteAttachmentAsync(Ulid id);
}