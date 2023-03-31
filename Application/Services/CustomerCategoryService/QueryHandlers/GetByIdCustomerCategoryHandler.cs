namespace Application.Services.CustomerCategoryService.QueryHandlers;

public class GetByIdCustomerCategoryHandler : IRequestHandler<GetByIdCustomerCategoryQuery, CustomerCategory?>
{
    private readonly ICustomerCategoryRepository _repository;

    public GetByIdCustomerCategoryHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory?> Handle(GetByIdCustomerCategoryQuery request, CancellationToken cancellationToken)
        => await _repository.GetCustomerCategoryByIdAsync(request.CustomerCategoryId);
}