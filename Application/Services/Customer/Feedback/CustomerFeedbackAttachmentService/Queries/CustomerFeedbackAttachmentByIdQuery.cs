namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.Queries;

public struct CustomerFeedbackAttachmentByIdQuery : IRequest<Result<CustomerFeedbackAttachmentResponse>>
{
    public Ulid Id { get; set; }
}