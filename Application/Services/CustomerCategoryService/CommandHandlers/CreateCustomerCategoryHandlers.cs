namespace Application.Services.CustomerCategoryService.CommandHandlers;

public class CreateCustomerCategoryHandlers : IRequestHandler<CreateCustomerCategoryCommand, CustomerCategory>
{
    private readonly ICustomerCategoryRepository _repository;

    public CreateCustomerCategoryHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory> Handle(CreateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        CustomerCategory customerCategory = new()
        {
            CustomerCategoryName = request.CustomerCategoryName,
            IsShown = request.IsShown,
        };

        await _repository.CreateCustomerCategoryAsync(customerCategory);
        return customerCategory;
    }
}
