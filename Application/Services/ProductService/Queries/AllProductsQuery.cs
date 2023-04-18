namespace Application.Services.ProductService.Queries;

public struct AllProductsQuery : IRequest<ICollection<Product>>
{
    public Ulid BusinessId { get; set; }
}