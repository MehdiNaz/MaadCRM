namespace Application.Services.ProductService.Commands;

public struct ChangeStateProductCommand : IRequest<Result<ProductResponse>>
{
    public Ulid Id { get; set; }
    public ProductStatus Status { get; set; }
}