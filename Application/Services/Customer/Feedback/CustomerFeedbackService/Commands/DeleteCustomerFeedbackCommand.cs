namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct DeleteCustomerFeedbackCommand : IRequest<Result<CustomerFeedbackResponse>>
{
    public Ulid Id { get; set; }
}
