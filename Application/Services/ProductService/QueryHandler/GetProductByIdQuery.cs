namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetProductByIdHandler : IRequestHandler<ProductByIdQuery, Result<Product>>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Product>> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetProductByIdAsync(request.ProductId)).Match(result => new Result<Product>(result), exception => new Result<Product>(exception));
        }
        catch (Exception e)
        {
            return new Result<Product>(new Exception(e.Message));
        }
    }
}