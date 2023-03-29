namespace Application.Services.CustomerCategoryService.CommandHandlers;

public class CreateCustomerCategoryHandlers : IRequestHandler<CreateCustomerCategoryCommand, CustCategory>
{
    private readonly ICustCategoryRepository _repository;

    public CreateCustomerCategoryHandlers(ICustCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustCategory> Handle(CreateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        CustCategory customerCategory = new()
        {
            CustomerCategoryName = request.CustomerCategoryName,
            IsShown = request.IsShown,
        };

        await _repository.CreateCustCategoryAsync(customerCategory);
        return customerCategory;
    }
}
