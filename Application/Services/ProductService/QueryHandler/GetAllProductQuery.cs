namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetAllProductHandler : IRequestHandler<GetAllProductsQuery, ICollection<Product>>
{
    private readonly IProductRepository _repository;

    public GetAllProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllProductsAsync())!;
}