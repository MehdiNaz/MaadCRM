namespace Application.Services.ProductService.Queries;

public struct GetProductByIdQuery : IRequest<Product>
{
    public Ulid ProductId { get; set; }
}