namespace Application.Services.ProductCategoryService.QueryHandler;

public readonly struct ProductCategoryBySearchItemHandler: IRequestHandler<ProductCategoryBySearchItemQuery, ICollection<ProductCategory>>
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryBySearchItemHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ProductCategory>> Handle(ProductCategoryBySearchItemQuery request, CancellationToken cancellationToken)
        => await _repository.SearchByItemsAsync(request.Q);
}