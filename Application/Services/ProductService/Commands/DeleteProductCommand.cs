namespace Application.Services.ProductService.Commands;

public struct DeleteProductCommand : IRequest<Product>
{
    public Ulid ProductId { get; set; }
}