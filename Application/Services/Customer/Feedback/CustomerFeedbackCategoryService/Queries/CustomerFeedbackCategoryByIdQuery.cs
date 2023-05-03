namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Queries;

public struct CustomerFeedbackCategoryByIdQuery : IRequest<Result<CustomerFeedbackCategory>>
{
    public Ulid Id { get; set; }
}