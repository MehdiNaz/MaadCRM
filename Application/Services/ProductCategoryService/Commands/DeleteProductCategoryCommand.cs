namespace Application.Services.ProductCategoryService.Commands;

public struct DeleteProductCategoryCommand : IRequest<ProductCategory>
{
    public Ulid Id { get; set; }
}