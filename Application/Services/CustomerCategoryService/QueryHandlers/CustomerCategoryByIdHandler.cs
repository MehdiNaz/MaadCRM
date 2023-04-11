namespace Application.Services.CustomerCategoryService.QueryHandlers;

public readonly struct CustomerCategoryByIdHandler : IRequestHandler<CustomerCategoryByIdQuery, CustomerCategory?>
{
    private readonly ICustomerCategoryRepository _repository;

    public CustomerCategoryByIdHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory?> Handle(CustomerCategoryByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetCustomerCategoryByIdAsync(request.CustomerCategoryId);
}