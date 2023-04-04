namespace Application.Services.ProductCategoryService.QueryHandler;

public class GetAllProductCategoryHandler : IRequestHandler<GetAllProductCategoriesQuery, ICollection<ProductCategory?>>
{
    private readonly IProductCategoryRepository _repository;

    public GetAllProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ProductCategory?>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllProductCategoriesAsync();
}