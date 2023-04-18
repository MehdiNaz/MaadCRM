namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, ProductCategory>
{
    private readonly IProductCategoryRepository _repository;

    public CreateProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCategory> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        ProductCategory item = new()
        {
            Order = request.Order,
            ProductCategoryName = request.ProductCategoryName,
            Description = request.Description,
            Icon = request.Icon,
            BusinessId = request.BusinessId
        };
        await _repository.CreateProductCategoryAsync(item);
        return item;
    }
}
