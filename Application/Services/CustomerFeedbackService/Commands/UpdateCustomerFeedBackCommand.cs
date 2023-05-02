namespace Application.Services.CustomerFeedbackService.Commands;

public struct UpdateCustomerFeedBackCommand : IRequest<CustomerFeedback>
{
    public Ulid Id { get; set; }
    public string Description { get; set; }
}