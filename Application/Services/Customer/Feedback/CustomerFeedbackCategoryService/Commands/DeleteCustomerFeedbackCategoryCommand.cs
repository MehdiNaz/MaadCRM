namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;

public struct DeleteCustomerFeedbackCategoryCommand : IRequest<Result<CustomerFeedbackCategory>>
{
    public Ulid Id { get; set; }
}