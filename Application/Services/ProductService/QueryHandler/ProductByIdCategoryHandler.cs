using Application.Responses.Product;

namespace Application.Services.ProductService.QueryHandler;

public readonly struct ProductByIdCategoryHandler: IRequestHandler<ProductByIdCategoryQuery, Result<ICollection<ProductResponse>>>
{
    private readonly IProductRepository _repository;

    public ProductByIdCategoryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProductResponse>>> Handle(ProductByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetProductByIdCategoryAsync(request.ProductCategoryId))
                .Match(result => new Result<ICollection<ProductResponse>>(result),
                exception => new Result<ICollection<ProductResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductResponse>>(new Exception(e.Message));
        }
    }
}