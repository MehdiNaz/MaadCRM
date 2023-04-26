namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetAllProductHandler : IRequestHandler<AllProductsQuery, Result<ICollection<ProductCategoryResponse>>>
{
    private readonly IProductRepository _repository;

    public GetAllProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProductCategoryResponse>>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllProductsAsync(request.BusinessId)).Match(
                result => new Result<ICollection<ProductCategoryResponse>>(result),
                exception => new Result<ICollection<ProductCategoryResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductCategoryResponse>>(new Exception(e.Message));
        }
    }
}