namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, Result<ProductCategory>>
{
    private readonly IProductCategoryRepository _repository;

    public DeleteProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategory>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteProductCategoryAsync(request)).Match(result => new Result<ProductCategory>(result), exception => new Result<ProductCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new Exception(e.Message));
        }
    }
}