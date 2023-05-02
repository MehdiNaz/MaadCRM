namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct DeleteCustomerCategoryCommandHandlers : IRequestHandler<DeleteCustomerCategoryCommand, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public DeleteCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(DeleteCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerCategoryAsync(request.Id))
                .Match(result => new Result<CustomerFeedbackCategory>(result), exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}