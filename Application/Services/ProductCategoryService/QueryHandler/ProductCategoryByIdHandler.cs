namespace Application.Services.ProductCategoryService.QueryHandler;

public readonly struct ProductCategoryByIdHandler : IRequestHandler<ProductCategoryByIdQuery, Result<ProductCategoryResponse>>
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryByIdHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategoryResponse>> Handle(ProductCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetProductCategoryByIdAsync(request.ProductCategoryId, request.BusinessId))
                .Match(result => new Result<ProductCategoryResponse>(result),
                    exception => new Result<ProductCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductCategoryResponse>(new Exception(e.Message));
        }
    }
}