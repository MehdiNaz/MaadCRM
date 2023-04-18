namespace Application.Services.ProductCategoryService.QueryHandler;

public readonly struct ProductCategoryByIdHandler : IRequestHandler<ProductCategoryByIdQuery, ProductCategory>
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryByIdHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCategory> Handle(ProductCategoryByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetProductCategoryByIdAsync(request.ProductCategoryId))!;
}