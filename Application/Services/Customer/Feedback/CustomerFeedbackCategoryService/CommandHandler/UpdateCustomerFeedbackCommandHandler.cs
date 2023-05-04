namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.CommandHandler;

public readonly struct UpdateCustomerFeedbackCommandHandler : IRequestHandler<UpdateCustomerFeedbackCategoryCommand, Result<CustomerFeedbackCategoryResponse>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public UpdateCustomerFeedbackCommandHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategoryResponse>> Handle(UpdateCustomerFeedbackCategoryCommand request, CancellationToken cancellationToken)
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
                .Match(result => new Result<CustomerFeedbackCategoryResponse>(result),
                    exception => new Result<CustomerFeedbackCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new Exception(e.Message));
        }
    }
}