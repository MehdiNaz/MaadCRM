namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct DeleteCustomerFeedbackCommand : IRequest<Result<CustomerFeedback>>
{
    public Ulid Id { get; set; }
}
