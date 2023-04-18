namespace Application.Services.ProductService.QueryHandler;

public readonly struct CustomerBySearchItemHandler : IRequestHandler<ProductBySearchItemQuery, ICollection<Product>?>
{
    private readonly IProductRepository _repository;

    public CustomerBySearchItemHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Product>?> Handle(ProductBySearchItemQuery request, CancellationToken cancellationToken)
        => await _repository.SearchByItemsAsync(request.Q);
}