using Application.Responses.Product;

namespace Application.Services.ProductCategoryService.QueryHandler;

public readonly struct AllProductCategoryHandler : IRequestHandler<AllProductCategoriesQuery, Result<ICollection<ProductCategoryResponse>>>
{
    private readonly IProductCategoryRepository _repository;

    public AllProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProductCategoryResponse>>> Handle(AllProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllProductCategoriesAsync(request.BusinessId))
                .Match(result => new Result<ICollection<ProductCategoryResponse>>(result),
                    exception => new Result<ICollection<ProductCategoryResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductCategoryResponse>>(new Exception(e.Message));
        }
    }
}