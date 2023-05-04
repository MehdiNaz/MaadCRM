namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.CommandHandler;

public readonly struct ChangeStateCustomerFeedbackCategoryCommandHandler : IRequestHandler<ChangeStatusCustomerFeedbackCategoryCommand, Result<CustomerFeedbackCategoryResponse>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public ChangeStateCustomerFeedbackCategoryCommandHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategoryResponse>> Handle(ChangeStatusCustomerFeedbackCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerFeedbackCategoryByIdAsync(request))
                .Match(result => new Result<CustomerFeedbackCategoryResponse>(result),
                    exception => new Result<CustomerFeedbackCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new Exception(e.Message));
        }
    }
}