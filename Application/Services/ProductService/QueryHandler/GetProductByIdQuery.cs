namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetProductByIdHandler : IRequestHandler<ProductByIdQuery, Product>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetProductByIdAsync(request.ProductId))!;
}