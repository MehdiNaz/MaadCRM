namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct ChangeStatusCustomerCategoryCommandHandler : IRequestHandler<ChangeStatusCustomerCategoryCommand, Result<CustomerCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public ChangeStatusCustomerCategoryCommandHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerCategory>> Handle(ChangeStatusCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerCategoryByIdAsync(request)).Match(result => new Result<CustomerCategory>(result), exception => new Result<CustomerCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new Exception(e.Message));
        }
    }
}