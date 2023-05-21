namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct DeleteCustomerFeedbackCommand : IRequest<string>
{
    public Ulid Id { get; set; }
}
