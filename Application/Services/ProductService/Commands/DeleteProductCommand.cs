using Application.Responses.Product;

namespace Application.Services.ProductService.Commands;

public struct DeleteProductCommand : IRequest<Result<ProductResponse>>
{
    public Ulid Id { get; set; }
}