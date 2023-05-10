namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct CreateCustomerFeedbackCommand : IRequest<Result<CustomerFeedback>>
{
    public string Description { get; set; }
    public Ulid IdCategory { get; set; }
    public Ulid? IdProduct { get; set; }
    public Ulid? IdCustomer { get; set; }
}
