namespace Application.Services.CustomerFeedbackService.Commands;

public struct ChangeStatusCustomerFeedBackCommand : IRequest<CustomerFeedback>
{
    public Ulid CustomerFeedbackId { get; set; }
    public Status CustomerFeedbackStatus { get; set; }
}