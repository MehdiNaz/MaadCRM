namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Queries;

public struct CustomerFeedbackBySearchItemQuery : IRequest<Result<ICollection<CustomerFeedbackResponse>>>
{
    public string Q { get; set; }
    public string UserId { get; set; }
}