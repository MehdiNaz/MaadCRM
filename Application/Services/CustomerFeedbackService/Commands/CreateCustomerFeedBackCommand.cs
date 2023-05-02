namespace Application.Services.CustomerFeedbackService.Commands;

public struct CreateCustomerFeedBackCommand : IRequest<CustomerFeedback>
{
    public string Description { get; set; }
}