namespace Application.Services.Customer.Feedback.CustomerFeedbackService.QueryHandler;

public readonly struct CustomerFeedbackByIdHandler : IRequestHandler<CustomerFeedbackByIdQuery, Result<CustomerFeedback>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public CustomerFeedbackByIdHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedback>> Handle(CustomerFeedbackByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerFeedbackByIdAsync(request.Id))
                .Match(result => new Result<CustomerFeedback>(result),
                    exception => new Result<CustomerFeedback>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new Exception(e.Message));
        }
    }
}