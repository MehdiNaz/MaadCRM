namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, Result<ProductCategoryResponse>>
{
    private readonly IProductCategoryRepository _repository;

    public UpdateProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategoryResponse>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
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
                BusinessId = request.BusinessId,
                IdUserUpdated = request.IdUserUpdated
            };
            return (await _repository.UpdateProductCategoryAsync(item))
                .Match(result => new Result<ProductCategoryResponse>(result),
                    exception => new Result<ProductCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductCategoryResponse>(new Exception(e.Message));
        }
    }
}
