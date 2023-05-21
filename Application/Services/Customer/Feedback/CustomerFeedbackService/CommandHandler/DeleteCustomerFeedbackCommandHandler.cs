namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct DeleteCustomerFeedbackCommandHandler : IRequestHandler<DeleteCustomerFeedbackCommand, string>
{
    private readonly ICustomerFeedbackRepository _repository;

    public DeleteCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(DeleteCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _repository.DeleteCustomerFeedbackAsync(request.Id);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}