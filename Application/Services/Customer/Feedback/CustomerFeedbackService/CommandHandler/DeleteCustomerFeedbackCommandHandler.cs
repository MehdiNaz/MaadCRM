namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct DeleteCustomerFeedbackCommandHandler : IRequestHandler<DeleteCustomerFeedbackCommand, Result<CustomerFeedbackResponse>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public DeleteCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackResponse>> Handle(DeleteCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerFeedbackAsync(request.Id))
                .Match(result => new Result<CustomerFeedbackResponse>(result),
                    exception => new Result<CustomerFeedbackResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new Exception(e.Message));
        }
    }
}