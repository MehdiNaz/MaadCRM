namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.Commands;

public struct UpdateCustomerFeedbackAttachmentCommand : IRequest<Result<CustomerFeedbackAttachmentResponse>>
{
    public Ulid Id { get; set; }
    public byte[] FileName { get; set; }
    public string Name { get; set; }
    public string Extenstion { get; set; }
    public Ulid IdCustomerFeedback { get; set; }
}