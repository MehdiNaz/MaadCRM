namespace Application.Services.ProductCategoryService.QueryHandler;

public class GetProductCategoryByIdHandler : IRequestHandler<GetProductCategoryByIdQuery, ProductCategory>
{
    private readonly IProductCategoryRepository _repository;

    public GetProductCategoryByIdHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCategory> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetProductCategoryByIdAsync(request.ProductCategoryId))!;
}