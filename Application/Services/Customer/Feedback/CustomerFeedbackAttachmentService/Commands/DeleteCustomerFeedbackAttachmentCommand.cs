namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.Commands;

public struct DeleteCustomerFeedbackAttachmentCommand : IRequest<Result<CustomerFeedbackAttachmentResponse>>
{
    public Ulid Id { get; set; }
}