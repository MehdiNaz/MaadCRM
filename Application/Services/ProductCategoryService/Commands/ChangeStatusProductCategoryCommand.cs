namespace Application.Services.ProductCategoryService.Commands;

public struct ChangeStatusProductCategoryCommand : IRequest<ProductCategory?>
{
    public Ulid ProductCategoryId { get; set; }
    public Status ProductCategoryStatus { get; set; }
}