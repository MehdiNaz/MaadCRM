namespace Application.Services.Customer.Feedback.CustomerFeedbackService.QueryHandler;

public readonly struct CustomerFeedbackByIdHandler : IRequestHandler<CustomerFeedbackByIdQuery, Result<CustomerFeedbackResponse>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public CustomerFeedbackByIdHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackResponse>> Handle(CustomerFeedbackByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerFeedbackByIdAsync(request.Id))
                .Match(result => new Result<CustomerFeedbackResponse>(result),
                    exception => new Result<CustomerFeedbackResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new Exception(e.Message));
        }
    }
}