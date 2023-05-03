namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;

public struct ChangeStatusCustomerFeedbackCategoryCommand : IRequest<Result<CustomerFeedbackCategory>>
{
    public Ulid Id { get; set; }
    public Status CustomerFeedbackCategoryStatus { get; set; }
}