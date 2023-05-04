namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Queries;

public struct CustomerFeedbackCategoryByIdQuery : IRequest<Result<CustomerFeedbackCategoryResponse>>
{
    public Ulid Id { get; set; }
}