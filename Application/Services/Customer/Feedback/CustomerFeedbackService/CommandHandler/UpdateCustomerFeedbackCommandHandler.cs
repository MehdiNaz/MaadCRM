namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct UpdateCustomerFeedbackCommandHandler : IRequestHandler<UpdateCustomerFeedbackCommand, Result<CustomerFeedbackResponse>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public UpdateCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackResponse>> Handle(UpdateCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerFeedbackCommand item = new()
            {
                Id = request.Id,
                Description = request.Description,
            };

            return (await _repository.UpdateCustomerFeedbackAsync(item))
                .Match(result => new Result<CustomerFeedbackResponse>(result),
                    exception => new Result<CustomerFeedbackResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new Exception(e.Message));
        }
    }
}