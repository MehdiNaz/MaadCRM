namespace Application.Interfaces.Customers.PeyGiry;

public interface IPeyGiryAttachmentRepository
{
    ValueTask<ICollection<PeyGiryAttachment?>> GetAllPeyGiryAttachmentsAsync();
    ValueTask<PeyGiryAttachment?> GetPeyGiryAttachmentByIdAsync(Ulid peyGiryAttachmentId);
    ValueTask<PeyGiryAttachment?> CreatePeyGiryAttachmentAsync(PeyGiryAttachment? entity);
    ValueTask<PeyGiryAttachment?> UpdatePeyGiryAttachmentAsync(PeyGiryAttachment entity, Ulid peyGiryAttachmentId);
    ValueTask<PeyGiryAttachment?> DeletePeyGiryAttachmentAsync(Ulid peyGiryAttachmentId);
}