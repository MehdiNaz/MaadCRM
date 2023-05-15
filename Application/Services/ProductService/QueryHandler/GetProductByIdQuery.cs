namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetProductByIdHandler : IRequestHandler<ProductByIdQuery, Result<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public GetProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductResponse>> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetProductByIdAsync(request.ProductId))
                .Match(result => new Result<ProductResponse>(result),
                    exception => new Result<ProductResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new Exception(e.Message));
        }
    }
}