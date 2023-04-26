namespace Application.Services.ProductCategoryService.QueryHandler;

public readonly struct ProductCategoryByIdHandler : IRequestHandler<ProductCategoryByIdQuery, Result<ProductCategory>>
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryByIdHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategory>> Handle(ProductCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetProductCategoryByIdAsync(request.ProductCategoryId)).Match(result => new Result<ProductCategory>(result), exception => new Result<ProductCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new Exception(e.Message));
        }
    }
}