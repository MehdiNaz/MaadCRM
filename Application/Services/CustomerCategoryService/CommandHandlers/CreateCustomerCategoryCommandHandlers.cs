namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct CreateCustomerCategoryCommandHandlers : IRequestHandler<CreateCustomerCategoryCommand, CustomerCategory>
{
    private readonly ICustomerCategoryRepository _repository;

    public CreateCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory> Handle(CreateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerCategoryCommand customerCategory = new()
        {
            UserId = request.UserId,
            CustomerCategoryName = request.CustomerCategoryName
        };

        return await _repository.CreateCustomerCategoryAsync(customerCategory);
    }
}
