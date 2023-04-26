namespace Application.Services.ProductCategoryService.QueryHandler;

public readonly struct AllProductCategoryHandler : IRequestHandler<AllProductCategoriesQuery, Result<ICollection<ProductCategory>>>
{
    private readonly IProductCategoryRepository _repository;

    public AllProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProductCategory>>> Handle(AllProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllProductCategoriesAsync(request.BusinessId)).Match(result => new Result<ICollection<ProductCategory>>(result), exception => new Result<ICollection<ProductCategory>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductCategory>>(new Exception(e.Message));
        }
    }
}