namespace Application.Services.Customer.Feedback.CustomerFeedbackService.QueryHandler;

public readonly struct AllCustomerFeedbacksHandler : IRequestHandler<AllCustomerFeedbacksQuery, Result<ICollection<CustomerFeedbackResponse>>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public AllCustomerFeedbacksHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedbackResponse>>> Handle(AllCustomerFeedbacksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerFeedbacksAsync(request.Id))
                .Match(result => new Result<ICollection<CustomerFeedbackResponse>>(result),
                    exception => new Result<ICollection<CustomerFeedbackResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackResponse>>(new Exception(e.Message));
        }
    }
}