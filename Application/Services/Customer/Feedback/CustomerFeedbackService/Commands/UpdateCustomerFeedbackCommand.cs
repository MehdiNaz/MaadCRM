namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct UpdateCustomerFeedbackCommand : IRequest<Result<CustomerFeedbackResponse>>
{
    public Ulid Id { get; set; }
    public string Description { get; set; }
    public string? IdUser { get; set; }
}
