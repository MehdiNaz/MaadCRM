namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;

public struct UpdateCustomerFeedbackCategoryCommand : IRequest<Result<CustomerFeedbackCategory>>
{
    public Ulid Id { get; set; }
    public string Name { get; set; }
    public FeedbackType TypeFeedback { get; set; }
    public bool PositiveNegative { get; set; }
    public Ulid IdBusiness { get; set; }
}