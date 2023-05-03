namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.CommandHandler;

public readonly struct DeleteCustomerFeedbackCategoryCommandHandler : IRequestHandler<DeleteCustomerFeedbackCategoryCommand, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public DeleteCustomerFeedbackCategoryCommandHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(DeleteCustomerFeedbackCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerFeedbackCategoryAsync(request.Id))
                .Match(result => new Result<CustomerFeedbackCategory>(result),
                    exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}