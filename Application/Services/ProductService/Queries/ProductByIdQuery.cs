using Application.Responses.Product;

namespace Application.Services.ProductService.Queries;

public struct ProductByIdQuery : IRequest<Result<ProductResponse>>
{
    public Ulid ProductId { get; set; }
}