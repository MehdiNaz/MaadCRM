namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.CommandHandler;

public readonly struct ChangeStateCustomerFeedbackCategoryCommandHandler : IRequestHandler<ChangeStateCustomerFeedbackCategoryCommand, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public ChangeStateCustomerFeedbackCategoryCommandHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(ChangeStateCustomerFeedbackCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerFeedbackCategoryByIdAsync(request))
                .Match(result => new Result<CustomerFeedbackCategory>(result),
                    exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}