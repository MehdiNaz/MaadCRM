namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct UpdateCustomerFeedbackCommandHandler : IRequestHandler<UpdateCustomerFeedbackCommand, Result<CustomerFeedback>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public UpdateCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedback>> Handle(UpdateCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerFeedbackCommand item = new()
            {
                Id = request.Id,
                Description = request.Description,
            };

            return (await _repository.UpdateCustomerFeedbackAsync(item))
                .Match(result => new Result<CustomerFeedback>(result),
                    exception => new Result<CustomerFeedback>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new Exception(e.Message));
        }
    }
}