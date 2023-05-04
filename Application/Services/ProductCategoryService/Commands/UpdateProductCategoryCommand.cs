namespace Application.Services.ProductCategoryService.Commands;

public struct UpdateProductCategoryCommand : IRequest<Result<ProductCategoryResponse>>
{
    public Ulid Id { get; set; }
    public byte? Order { get; set; }
    public required string ProductCategoryName { get; set; }
    public string Description { get; set; }
    public string? Icon { get; set; }
    public Ulid BusinessId { get; set; }
    public string IdUserUpdated { get; set; }
}