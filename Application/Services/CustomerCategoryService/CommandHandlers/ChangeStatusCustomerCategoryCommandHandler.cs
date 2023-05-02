namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct ChangeStatusCustomerCategoryCommandHandler : IRequestHandler<ChangeStatusCustomerCategoryCommand, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public ChangeStatusCustomerCategoryCommandHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(ChangeStatusCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerCategoryByIdAsync(request)).Match(result => new Result<CustomerFeedbackCategory>(result), exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}