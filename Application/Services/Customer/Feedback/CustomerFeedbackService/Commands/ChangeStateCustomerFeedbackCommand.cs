namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct ChangeStateCustomerFeedbackCommand : IRequest<Result<CustomerFeedbackResponse>>
{
    public Ulid Id { get; set; }
    public StatusType CustomerFeedbackStatusType { get; set; }
}
