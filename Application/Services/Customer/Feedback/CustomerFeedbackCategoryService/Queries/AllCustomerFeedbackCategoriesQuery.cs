namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Queries;

public struct AllCustomerFeedbackCategoriesQuery : IRequest<Result<ICollection<CustomerFeedbackCategoryResponse>>>
{
    public Ulid BusinessId { get; set; }
}