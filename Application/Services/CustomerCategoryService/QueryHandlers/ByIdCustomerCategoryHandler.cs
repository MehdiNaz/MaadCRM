namespace Application.Services.CustomerCategoryService.QueryHandlers;

public class ByIdCustomerCategoryHandler : IRequestHandler<ByIdCustomerCategoryQuery, CustomerCategory?>
{
    private readonly ICustomerCategoryRepository _repository;

    public ByIdCustomerCategoryHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory?> Handle(ByIdCustomerCategoryQuery request, CancellationToken cancellationToken)
        => await _repository.GetCustomerCategoryByIdAsync(request.CustomerCategoryId);
}