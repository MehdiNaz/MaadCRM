namespace Application.Services.ProductCategoryService.Commands;

public struct ChangeStatusProductCategoryCommand : IRequest<ProductCategory?>
{
    public Ulid Id { get; set; }
    public Status ProductCategoryStatus { get; set; }
}