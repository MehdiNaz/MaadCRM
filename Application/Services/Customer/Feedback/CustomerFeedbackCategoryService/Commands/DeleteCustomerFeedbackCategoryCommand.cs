namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;

public struct DeleteCustomerFeedbackCategoryCommand : IRequest<Result<CustomerFeedbackCategoryResponse>>
{
    public Ulid Id { get; set; }
}