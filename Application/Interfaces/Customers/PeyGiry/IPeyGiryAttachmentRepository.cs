namespace Application.Interfaces.Customers.PeyGiry;

public interface IPeyGiryAttachmentRepository
{
    ValueTask<ICollection<PeyGiryAttachment?>> GetAllPeyGiryAttachmentsAsync();
    ValueTask<PeyGiryAttachment?> GetPeyGiryAttachmentByIdAsync(Ulid peyGiryAttachmentId);
    ValueTask<PeyGiryAttachment?> ChangeStatusPeyGiryAttachmentByIdAsync(ChangeStatusPeyGiryAttachmentCommand request);
    ValueTask<PeyGiryAttachment?> CreatePeyGiryAttachmentAsync(CreatePeyGiryAttachmentCommand request);
    ValueTask<PeyGiryAttachment?> UpdatePeyGiryAttachmentAsync(UpdatePeyGiryAttachmentCommand request);
    ValueTask<PeyGiryAttachment?> DeletePeyGiryAttachmentAsync(DeletePeyGiryAttachmentCommand request);
}