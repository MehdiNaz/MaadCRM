namespace Application.Services.ProductCategoryService.QueryHandler;

public readonly struct ProductCategoryBySearchItemHandler : IRequestHandler<ProductCategoryBySearchItemQuery, Result<ICollection<ProductCategory>>>
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryBySearchItemHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProductCategory>>> Handle(ProductCategoryBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByItemsAsync(request.Q)).Match(result => new Result<ICollection<ProductCategory>>(result), exception => new Result<ICollection<ProductCategory>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductCategory>>(new Exception(e.Message));
        }
    }
}