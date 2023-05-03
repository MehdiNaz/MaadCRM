namespace Application.Services.Customer.Feedback.CustomerFeedbackService.Queries;

public struct CustomerFeedbackByIdQuery : IRequest<Result<CustomerFeedback>>
{
    public Ulid Id { get; set; }
}