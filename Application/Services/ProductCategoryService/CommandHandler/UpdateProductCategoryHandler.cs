namespace Application.Services.ProductCategoryService.CommandHandler;

public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, ProductCategory>
{
    private readonly IProductCategoryRepository _repository;

    public UpdateProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCategory> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        ProductCategory item = new()
        {
            ParentId = request.ParentId,
            Order = request.Order,
            ProductCategoryName = request.ProductCategoryName,
            Description = request.Description,
            Icon = request.Icon
        };
        await _repository.UpdateProductCategoryAsync(item, request.ProductCategoryId);
        return item;
    }
}