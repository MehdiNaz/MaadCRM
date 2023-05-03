namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct DeleteCustomerFeedbackCommandHandler : IRequestHandler<DeleteCustomerFeedbackCommand, Result<CustomerFeedback>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public DeleteCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedback>> Handle(DeleteCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerFeedbackAsync(request.Id))
                .Match(result => new Result<CustomerFeedback>(result),
                    exception => new Result<CustomerFeedback>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new Exception(e.Message));
        }
    }
}