namespace Application.Services.CustomerCategoryService.QueryHandlers;

public class GetAllCustomerCategoryHandler : IRequestHandler<GetAllItemsCustomerCategoryQuery, ICollection<CustomerCategory?>>
{
    private readonly ICustomerCategoryRepository _repository;

    public GetAllCustomerCategoryHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerCategory?>> Handle(GetAllItemsCustomerCategoryQuery request,
        CancellationToken cancellationToken)
        => await _repository.GetAllCustomerCategoryAsync();
}