namespace Application.Services.ProductCategoryService.QueryHandler;

public readonly struct AllProductCategoryHandler : IRequestHandler<AllProductCategoriesQuery, ICollection<ProductCategory>>
{
    private readonly IProductCategoryRepository _repository;

    public AllProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ProductCategory>> Handle(AllProductCategoriesQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllProductCategoriesAsync(request.BusinessId);
}