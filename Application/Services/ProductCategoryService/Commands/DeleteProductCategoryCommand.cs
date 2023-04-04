namespace Application.Services.ProductCategoryService.Commands;

public struct DeleteProductCategoryCommand : IRequest<ProductCategory>
{
    public Ulid ProductCategoryId { get; set; }
}