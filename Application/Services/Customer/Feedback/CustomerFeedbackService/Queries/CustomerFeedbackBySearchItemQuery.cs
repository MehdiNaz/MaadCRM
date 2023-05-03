namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Queries;

public struct CustomerFeedbackBySearchItemQuery : IRequest<Result<ICollection<CustomerFeedback>>>
{
    public string Q { get; set; }
}