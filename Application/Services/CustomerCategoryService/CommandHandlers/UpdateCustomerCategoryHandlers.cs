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
            IsDeleted = request.IsDeleted,
            IsShown = request.IsShown,
            CategoryId = request.CategoryId
        };

        await _repository.UpdateCustCategoryAsync(customerCategory, request.CustCategoryId);
        return customerCategory;
    }
}
