namespace Application.Services.CustomerFeedbackService.Commands;

public struct ChangeStatusCustomerFeedBackCommand : IRequest<CustomerFeedback>
{
    public Ulid Id { get; set; }
    public Status CustomerFeedbackStatus { get; set; }
}