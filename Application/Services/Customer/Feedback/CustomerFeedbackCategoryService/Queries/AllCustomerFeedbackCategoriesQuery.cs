namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Queries;

public struct AllCustomerFeedbackCategoriesQuery : IRequest<Result<ICollection<CustomerFeedbackCategory>>>
{
    public Ulid BusinessId { get; set; }
}