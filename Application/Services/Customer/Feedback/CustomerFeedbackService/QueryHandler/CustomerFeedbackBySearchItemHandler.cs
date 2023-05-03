namespace Application.Services.Customer.Feedback.CustomerFeedbackService.QueryHandler;

public readonly struct CustomerFeedbackBySearchItemHandler : IRequestHandler<CustomerFeedbackBySearchItemQuery, Result<ICollection<CustomerFeedback>>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public CustomerFeedbackBySearchItemHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedback>>> Handle(CustomerFeedbackBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByItemsAsync(request.Q))
                .Match(result => new Result<ICollection<CustomerFeedback>>(result),
                exception => new Result<ICollection<CustomerFeedback>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedback>>(new Exception(e.Message));
        }
    }
}