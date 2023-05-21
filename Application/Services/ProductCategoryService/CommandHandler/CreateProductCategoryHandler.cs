using Application.Responses.Product;

namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, Result<ProductCategoryResponse>>
{
    private readonly IProductCategoryRepository _repository;

    public CreateProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategoryResponse>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateProductCategoryCommand item = new()
            {
                Order = request.Order,
                ProductCategoryName = request.ProductCategoryName,
                Description = request.Description,
                Icon = request.Icon,
                BusinessId = request.BusinessId,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };
            return (await _repository.CreateProductCategoryAsync(item)).
                Match(result => new Result<ProductCategoryResponse>(result),
                exception => new Result<ProductCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductCategoryResponse>(new Exception(e.Message));
        }
    }
}
