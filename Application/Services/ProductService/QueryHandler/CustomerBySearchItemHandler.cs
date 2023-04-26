namespace Application.Services.ProductService.QueryHandler;

public readonly struct CustomerBySearchItemHandler : IRequestHandler<ProductBySearchItemQuery, Result<ICollection<Product>>>
{
    private readonly IProductRepository _repository;

    public CustomerBySearchItemHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<Product>>> Handle(ProductBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByItemsAsync(request.Q)).Match(result => new Result<ICollection<Product>>(result), exception => new Result<ICollection<Product>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<Product>>(new Exception(e.Message));
        }
    }
}