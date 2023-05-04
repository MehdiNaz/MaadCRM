namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Queries;

public struct CustomerFeedbackCategoryBySearchItemQuery : IRequest<Result<ICollection<CustomerFeedbackCategoryResponse>>>
{
    public string Q { get; set; }
    public Ulid BusinessId { get; set; }
}