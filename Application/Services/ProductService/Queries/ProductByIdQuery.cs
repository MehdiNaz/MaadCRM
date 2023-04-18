namespace Application.Services.ProductService.Queries;

public struct ProductByIdQuery : IRequest<Product>
{
    public Ulid ProductId { get; set; }
}