namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;

public struct ChangeStateCustomerFeedbackCategoryCommand : IRequest<Result<CustomerFeedbackCategory>>
{
    public Ulid Id { get; set; }
    public Status CustomerFeedbackCategoryStatus { get; set; }
}