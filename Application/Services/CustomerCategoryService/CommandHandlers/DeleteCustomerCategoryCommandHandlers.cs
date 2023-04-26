namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct DeleteCustomerCategoryCommandHandlers : IRequestHandler<DeleteCustomerCategoryCommand, Result<CustomerCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public DeleteCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerCategory>> Handle(DeleteCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerCategoryAsync(request.Id))
                .Match(result => new Result<CustomerCategory>(result), exception => new Result<CustomerCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new Exception(e.Message));
        }
    }
}