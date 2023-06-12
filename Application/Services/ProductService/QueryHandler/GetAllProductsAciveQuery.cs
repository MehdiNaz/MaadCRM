using Application.Responses.Product;

namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetAllProductsActiveHandler : IRequestHandler<AllProductsActiveQuery, Result<ICollection<ProductResponse>>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsActiveHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProductResponse>>> Handle(AllProductsActiveQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllProductsAsync(request.BusinessId)).Match(
                result => new Result<ICollection<ProductResponse>>(result),
                exception => new Result<ICollection<ProductResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductResponse>>(new Exception(e.Message));
        }
    }
}