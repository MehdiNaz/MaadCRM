namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Queries;

public struct AllCustomerFeedbacksQuery : IRequest<Result<ICollection<CustomerFeedback>>>
{
}