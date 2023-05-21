using Application.Responses.Product;

namespace Application.Services.ProductService.Queries;

public struct AllProductsQuery : IRequest<Result<ICollection<ProductResponse>>>
{
    public Ulid BusinessId { get; set; }
}