namespace Application.Services.CustomerFeedbackService.Commands;

public struct UpdateCustomerFeedBackCommand : IRequest<CustomerFeedback>
{
    public Ulid Id { get; set; }
    public string FeedbackName { get; set; }
    public int DisplayOrder { get; set; }
    public decimal Point { get; set; }
    public int BalancePoint { get; set; }
}