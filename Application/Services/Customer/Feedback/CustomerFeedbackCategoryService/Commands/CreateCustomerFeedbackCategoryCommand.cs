namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.Commands;

public struct CreateCustomerFeedbackCategoryCommand : IRequest<Result<CustomerFeedbackCategoryResponse>>
{
    public string Name { get; set; }
    public FeedbackType TypeFeedback { get; set; }
    public bool PositiveNegative { get; set; }
    public Ulid IdBusiness { get; set; }
    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
}