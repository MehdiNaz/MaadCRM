namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct ChangeStatusProductCategoryCommandHandler : IRequestHandler<ChangeStatusProductCategoryCommand, Result<ProductCategory>>
{
    private readonly IProductCategoryRepository _repository;

    public ChangeStatusProductCategoryCommandHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategory>> Handle(ChangeStatusProductCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusProductCategoryByIdAsync(request)).Match(result => new Result<ProductCategory>(result), exception => new Result<ProductCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductCategory>(new Exception(e.Message));
        }
    }
}