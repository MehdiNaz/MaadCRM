namespace Application.Services.ProductCategoryService.Commands;

public struct UpdateProductCategoryCommand : IRequest<ProductCategory>
{
    public Ulid ProductCategoryId { get; set; }
    public Ulid ParentId { get; set; }
    public byte? Order { get; set; }
    public required string ProductCategoryName { get; set; }
    public string Description { get; set; }
    public string? Icon { get; set; }
}