namespace Application.Services.CustomerCategoryService.QueryHandlers;

public readonly struct CustomerCategoryByIdHandler : IRequestHandler<CustomerCategoryByIdQuery, Result<CustomerCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public CustomerCategoryByIdHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerCategory>> Handle(CustomerCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerCategoryByIdAsync(request.CustomerCategoryId, request.UserId)).Match(result => new Result<CustomerCategory>(result), exception => new Result<CustomerCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new Exception(e.Message));
        }
    }
}