namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct ChangeStateCustomerFeedbackCommandHandler : IRequestHandler<ChangeStateCustomerFeedbackCommand, Result<CustomerFeedback>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public ChangeStateCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedback>> Handle(ChangeStateCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerFeedbacksByIdAsync(request))
                .Match(result => new Result<CustomerFeedback>(result),
                    exception => new Result<CustomerFeedback>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new Exception(e.Message));
        }
    }
}