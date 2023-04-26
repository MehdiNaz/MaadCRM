namespace Application.Services.ProductService.Commands;

public struct DeleteProductCommand : IRequest<Result<Product>>
{
    public Ulid Id { get; set; }
}