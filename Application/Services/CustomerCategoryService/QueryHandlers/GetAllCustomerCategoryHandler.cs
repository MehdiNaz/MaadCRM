namespace Application.Services.CustomerCategoryService.QueryHandlers;

public class GetAllCustomerCategoryHandler : IRequestHandler<GetAllItemsCustomerCategoryQuery, ICollection<CustCategory?>>
{
    private readonly ICustCategoryRepository _repository;

    public GetAllCustomerCategoryHandler(ICustCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustCategory?>> Handle(GetAllItemsCustomerCategoryQuery request,
        CancellationToken cancellationToken)
        => await _repository.GetAllCustCategoryAsync();
}