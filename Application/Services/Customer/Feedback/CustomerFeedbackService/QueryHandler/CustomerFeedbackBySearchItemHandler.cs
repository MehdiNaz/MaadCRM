namespace Application.Services.Customer.Feedback.CustomerFeedbackService.QueryHandler;

public readonly struct CustomerFeedbackBySearchItemHandler : IRequestHandler<CustomerFeedbackBySearchItemQuery, Result<ICollection<CustomerFeedbackResponse>>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public CustomerFeedbackBySearchItemHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedbackResponse>>> Handle(CustomerFeedbackBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByItemsAsync(request.Q))
                .Match(result => new Result<ICollection<CustomerFeedbackResponse>>(result),
                exception => new Result<ICollection<CustomerFeedbackResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackResponse>>(new Exception(e.Message));
        }
    }
}