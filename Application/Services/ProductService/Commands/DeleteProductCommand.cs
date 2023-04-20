namespace Application.Services.ProductService.Commands;

public struct DeleteProductCommand : IRequest<Product>
{
    public Ulid Id { get; set; }
}