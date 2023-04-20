namespace Application.Services.CustomerFeedbackService.Commands;

public struct DeleteCustomerFeedBackCommand : IRequest<CustomerFeedback>
{
    public Ulid Id { get; set; }
}