namespace Application.Services.CustomerCategoryService.CommandHandlers;

public class CreateCustomerCategoryCommandHandlers : IRequestHandler<CreateCustomerCategoryCommand, CustomerCategory>
{
    private readonly ICustomerCategoryRepository _repository;

    public CreateCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory> Handle(CreateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        CustomerCategory customerCategory = new()
        {
            CustomerCategoryName = request.CustomerCategoryName,
        };

        await _repository.CreateCustomerCategoryAsync(customerCategory);
        return customerCategory;
    }
}
