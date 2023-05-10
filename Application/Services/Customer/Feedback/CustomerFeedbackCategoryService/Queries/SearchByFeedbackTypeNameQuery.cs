namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Queries;

public struct SearchByFeedbackTypeNameQuery : IRequest<Result<ICollection<CustomerFeedbackCategoryResponse>>>
{
    public FeedbackType Type { get; set; }
}