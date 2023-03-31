namespace Application.Services.CustomerCategoryService.CommandHandlers;

public class UpdateCustomerCategoryHandlers : IRequestHandler<UpdateCustomerCategoryCommand, CustomerCategory>
{
    private readonly ICustomerCategoryRepository _repository;

    public UpdateCustomerCategoryHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory> Handle(UpdateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        CustomerCategory customerCategory = new()
        {
            CustomerCategoryName = request.CustomerCategoryName,
            IsShown = request.IsShown
        };

        await _repository.UpdateCustomerCategoryAsync(customerCategory, request.CustomerCategoryId);
        return customerCategory;
    }
}
