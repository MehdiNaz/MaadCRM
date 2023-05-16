namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Queries;

public struct CustomerFeedbackByIdQuery : IRequest<Result<CustomerFeedbackResponse>>
{
    public Ulid Id { get; set; }
}