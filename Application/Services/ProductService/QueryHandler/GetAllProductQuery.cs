namespace Application.Services.ProductService.QueryHandler;

public readonly struct GetAllProductHandler : IRequestHandler<AllProductsQuery, ICollection<ProductCategoryResponse>>
{
    private readonly IProductRepository _repository;

    public GetAllProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ProductCategoryResponse>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllProductsAsync(request.BusinessId))!;
}