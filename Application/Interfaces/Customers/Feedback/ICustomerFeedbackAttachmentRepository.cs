namespace Application.Interfaces.Customers.Feedback;

public interface ICustomerFeedbackAttachmentRepository
{
    ValueTask<Result<ICollection<CustomerFeedbackAttachmentResponse>>> GetAllCustomerFeedbackAttachmentAsync(Ulid customerFeedbackId);
    ValueTask<Result<CustomerFeedbackAttachmentResponse>> GetCustomerFeedbackAttachmentByIdAsync(Ulid attachmentId);
    ValueTask<Result<CustomerFeedbackAttachmentResponse>> CreateCustomerFeedbackAttachmentAsync(CreateCustomerFeedbackAttachmentCommand request);
    ValueTask<Result<CustomerFeedbackAttachmentResponse>> UpdateCustomerFeedbackAttachmentAsync(UpdateCustomerFeedbackAttachmentCommand request);
    ValueTask<Result<CustomerFeedbackAttachmentResponse>> DeleteCustomerFeedbackAttachmentAsync(Ulid attachmentId);
}
