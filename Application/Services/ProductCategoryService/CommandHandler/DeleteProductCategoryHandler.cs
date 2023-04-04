namespace Application.Services.ProductCategoryService.CommandHandler;

public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, ProductCategory>
{
    private readonly IProductCategoryRepository _repository;

    public DeleteProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCategory> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteProductCategoryAsync(request.ProductCategoryId))!;
}