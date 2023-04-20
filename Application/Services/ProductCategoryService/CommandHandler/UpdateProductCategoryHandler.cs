namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, ProductCategory>
{
    private readonly IProductCategoryRepository _repository;

    public UpdateProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCategory> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        UpdateProductCategoryCommand item = new()
        {
            Id = request.Id,
            Order = request.Order,
            ProductCategoryName = request.ProductCategoryName,
            Description = request.Description,
            Icon = request.Icon,
            BusinessId = request.BusinessId
        };
        return await _repository.UpdateProductCategoryAsync(item);
    }
}
