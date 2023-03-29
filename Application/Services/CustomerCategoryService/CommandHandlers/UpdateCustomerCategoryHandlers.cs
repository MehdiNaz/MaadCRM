namespace Application.Services.CustomerCategoryService.CommandHandlers;

public class UpdateCustomerCategoryHandlers : IRequestHandler<UpdateCustomerCategoryCommand, CustCategory>
{
    private readonly ICustCategoryRepository _repository;

    public UpdateCustomerCategoryHandlers(ICustCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustCategory> Handle(UpdateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        CustCategory customerCategory = new()
        {
            CustomerCategoryName = request.CustomerCategoryName,
            IsShown = request.IsShown
        };

        await _repository.UpdateCustCategoryAsync(customerCategory, request.CustCategoryId);
        return customerCategory;
    }
}
