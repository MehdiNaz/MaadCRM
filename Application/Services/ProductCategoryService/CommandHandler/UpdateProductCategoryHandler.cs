namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, Result<ProductCategory>>
{
    private readonly IProductCategoryRepository _repository;

    public UpdateProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategory>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        try
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
            return (await _repository.UpdateProductCategoryAsync(item)).Match(result => new Result<ProductCategory>(result), exception => new Result<ProductCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new Exception(e.Message));
        }
    }
}
