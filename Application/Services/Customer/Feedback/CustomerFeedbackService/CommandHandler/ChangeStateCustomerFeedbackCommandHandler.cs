namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct ChangeStateCustomerFeedbackCommandHandler : IRequestHandler<ChangeStateCustomerFeedbackCommand, Result<CustomerFeedbackResponse>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public ChangeStateCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackResponse>> Handle(ChangeStateCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerFeedbacksByIdAsync(request))
                .Match(result => new Result<CustomerFeedbackResponse>(result),
                    exception => new Result<CustomerFeedbackResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new Exception(e.Message));
        }
    }
}