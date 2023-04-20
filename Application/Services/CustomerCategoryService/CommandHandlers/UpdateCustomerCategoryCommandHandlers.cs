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
        UpdateCustomerCategoryCommand customerCategory = new()
        {
            Id = request.Id,
            CustomerCategoryName = request.CustomerCategoryName,
            UserId = request.UserId
        };

        return await _repository.UpdateCustomerCategoryAsync(customerCategory);
    }
}
