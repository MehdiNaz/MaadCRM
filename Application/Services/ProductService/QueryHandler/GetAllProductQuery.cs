namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetAllProductHandler : IRequestHandler<AllProductsQuery, Result<ICollection<ProductResponse>>>
{
    private readonly IProductRepository _repository;

    public GetAllProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProductResponse>>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
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