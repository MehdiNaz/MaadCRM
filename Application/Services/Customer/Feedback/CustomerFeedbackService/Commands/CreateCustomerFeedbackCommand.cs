namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Commands;

public struct CreateCustomerFeedbackCommand : IRequest<Result<CustomerFeedbackResponse>>
{
    public string Description { get; set; }
    public Ulid IdCategory { get; set; }
    public Ulid? IdProduct { get; set; }
    public Ulid? IdCustomer { get; set; }
    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
    public string IdUser { get; set; }
}
