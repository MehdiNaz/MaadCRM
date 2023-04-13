namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct ChangeStatusProductCategoryCommandHandler : IRequestHandler<ChangeStatusProductCategoryCommand, ProductCategory?>
{
    private readonly IProductCategoryRepository _repository;

    public ChangeStatusProductCategoryCommandHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCategory?> Handle(ChangeStatusProductCategoryCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusProductCategoryByIdAsync(request.ProductCategoryStatus, request.ProductCategoryId);
}