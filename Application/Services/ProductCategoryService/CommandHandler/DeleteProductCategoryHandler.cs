using Application.Responses.Product;

namespace Application.Services.ProductCategoryService.CommandHandler;

public readonly struct DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, Result<ProductCategoryResponse>>
{
    private readonly IProductCategoryRepository _repository;

    public DeleteProductCategoryHandler(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCategoryResponse>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteProductCategoryAsync(request.Id))
                .Match(result => new Result<ProductCategoryResponse>(result),
                    exception => new Result<ProductCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductCategoryResponse>(new Exception(e.Message));
        }
    }
}