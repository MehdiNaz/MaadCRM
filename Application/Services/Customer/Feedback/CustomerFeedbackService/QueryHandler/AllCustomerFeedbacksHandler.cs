namespace Application.Services.Customer.Feedback.CustomerFeedbackService.QueryHandler;

public readonly struct AllCustomerFeedbacksHandler : IRequestHandler<AllCustomerFeedbacksQuery, Result<ICollection<CustomerFeedback>>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public AllCustomerFeedbacksHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedback>>> Handle(AllCustomerFeedbacksQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerFeedbacksAsync())
                .Match(result => new Result<ICollection<CustomerFeedback>>(result),
                    exception => new Result<ICollection<CustomerFeedback>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedback>>(new Exception(e.Message));
        }
    }
}