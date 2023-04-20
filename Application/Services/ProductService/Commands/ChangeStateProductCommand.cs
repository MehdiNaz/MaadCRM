namespace Application.Services.ProductService.Commands;

public struct ChangeStateProductCommand : IRequest<Product>
{
    public Ulid Id { get; set; }
    public ProductStatus Status { get; set; }
}