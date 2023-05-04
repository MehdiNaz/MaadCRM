namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.Commands;

public struct CreateCustomerFeedbackAttachmentCommand : IRequest<Result<CustomerFeedbackAttachmentResponse>>
{
    public byte[] FileName { get; set; }
    public string Name { get; set; }
    public string Extenstion { get; set; }
    public Ulid IdCustomerFeedback { get; set; }
}