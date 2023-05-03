namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct UpdateCustomerFeedbackCommand : IRequest<Result<CustomerFeedback>>
{
    public Ulid Id { get; set; }
    public string Description { get; set; }
    public Ulid IdCategory { get; set; }
    public Ulid IdProduct { get; set; }
    public Ulid IdCustomer { get; set; }
}
