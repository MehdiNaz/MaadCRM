using Application.Responses.Product;

namespace Application.Services.ProductService.QueryHandler;

public readonly struct CustomerBySearchItemHandler : IRequestHandler<ProductBySearchItemQuery, Result<ICollection<ProductResponse>>>
{
    private readonly IProductRepository _repository;

    public CustomerBySearchItemHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProductResponse>>> Handle(ProductBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByItemsAsync(request.Q))
                .Match(result => new Result<ICollection<ProductResponse>>(result),
                    exception => new Result<ICollection<ProductResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProductResponse>>(new Exception(e.Message));
        }
    }
}