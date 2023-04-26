namespace Application.Services.ProductCategoryService.Commands;

public struct DeleteProductCategoryCommand : IRequest<Result<ProductCategory>>
{
    public Ulid Id { get; set; }
}