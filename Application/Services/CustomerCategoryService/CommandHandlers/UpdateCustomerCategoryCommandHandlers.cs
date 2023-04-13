namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct UpdateCustomerCategoryCommandHandlers : IRequestHandler<UpdateCustomerCategoryCommand, CustomerCategory>
{
    private readonly ICustomerCategoryRepository _repository;

    public UpdateCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory> Handle(UpdateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        CustomerCategory customerCategory = new()
        {
            UserId = request.UserId,
            CustomerCategoryId = request.CustomerCategoryId,
            CustomerCategoryName = request.CustomerCategoryName
        };

        await _repository.UpdateCustomerCategoryAsync(customerCategory);
        return customerCategory;
    }
}
