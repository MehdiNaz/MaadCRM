namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct ChangeStateCustomerFeedbackCommand : IRequest<Result<CustomerFeedback>>
{
    public Ulid Id { get; set; }
    public StatusType CustomerFeedbackStatusType { get; set; }
}
