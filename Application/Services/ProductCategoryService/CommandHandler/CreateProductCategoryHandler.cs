namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, Result<ProductCategory>>
{
    private readonly IProductCategoryRepository _repository;

    public CreateProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategory>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateProductCategoryCommand item = new()
            {
                Order = request.Order,
                ProductCategoryName = request.ProductCategoryName,
                Description = request.Description,
                Icon = request.Icon,
                BusinessId = request.BusinessId
            };
            return await _repository.CreateProductCategoryAsync(item);
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new Exception(e.Message));
        }
    }
}
