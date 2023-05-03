namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.CommandHandler;

public readonly struct UpdateCustomerFeedbackCommandHandler : IRequestHandler<UpdateCustomerFeedbackCategoryCommand, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public UpdateCustomerFeedbackCommandHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(UpdateCustomerFeedbackCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerFeedbackCategoryCommand item = new()
            {
                Id = request.Id,
                PositiveNegative = request.PositiveNegative,
                TypeFeedback = request.TypeFeedback,
                Name = request.Name
            };

            return (await _repository.UpdateCustomerFeedbackCategoryAsync(item))
                .Match(result => new Result<CustomerFeedbackCategory>(result),
                    exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}