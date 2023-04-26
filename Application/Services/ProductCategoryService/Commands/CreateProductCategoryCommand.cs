namespace Application.Services.ProductCategoryService.Commands;

public struct CreateProductCategoryCommand : IRequest<Result<ProductCategory>>
{
    public byte? Order { get; set; }
    public required string ProductCategoryName { get; set; }
    public string Description { get; set; }
    public string? Icon { get; set; }
    public Ulid BusinessId { get; set; }
}