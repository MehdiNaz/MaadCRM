namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.CommandHandler;

public readonly struct DeleteCustomerFeedbackCategoryCommandHandler : IRequestHandler<DeleteCustomerFeedbackCategoryCommand, Result<CustomerFeedbackCategoryResponse>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public DeleteCustomerFeedbackCategoryCommandHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategoryResponse>> Handle(DeleteCustomerFeedbackCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerFeedbackCategoryAsync(request.Id))
                .Match(result => new Result<CustomerFeedbackCategoryResponse>(result),
                    exception => new Result<CustomerFeedbackCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new Exception(e.Message));
        }
    }
}