namespace Application.Services.ProductService.Commands;

public struct ChangeStateProductCommand : IRequest<Result<Product>>
{
    public Ulid Id { get; set; }
    public ProductStatus Status { get; set; }
}