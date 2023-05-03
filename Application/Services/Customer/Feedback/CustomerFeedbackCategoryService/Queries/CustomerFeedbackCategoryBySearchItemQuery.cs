namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Queries;

public struct CustomerFeedbackCategoryBySearchItemQuery : IRequest<Result<CustomerFeedbackCategory>>
{
    public string Q { get; set; }
}