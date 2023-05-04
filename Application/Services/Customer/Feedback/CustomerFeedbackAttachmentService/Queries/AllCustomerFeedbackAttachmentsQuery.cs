namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.Queries;

public struct AllCustomerFeedbackAttachmentsQuery : IRequest<Result<ICollection<CustomerFeedbackAttachmentResponse>>>
{
    public Ulid CustomerFeedbackId { get; set; }
}