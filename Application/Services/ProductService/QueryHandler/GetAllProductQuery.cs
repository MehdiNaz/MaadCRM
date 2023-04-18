namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetAllProductHandler : IRequestHandler<AllProductsQuery, ICollection<Product>>
{
    private readonly IProductRepository _repository;

    public GetAllProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Product>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllProductsAsync(request.BusinessId))!;
}