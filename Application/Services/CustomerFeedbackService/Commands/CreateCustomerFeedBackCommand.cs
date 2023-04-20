namespace Application.Services.CustomerFeedbackService.Commands;

public struct CreateCustomerFeedBackCommand : IRequest<CustomerFeedback>
{
    public string FeedbackName { get; set; }
    public int DisplayOrder { get; set; }
    public decimal Point { get; set; }
    public int BalancePoint { get; set; }
}