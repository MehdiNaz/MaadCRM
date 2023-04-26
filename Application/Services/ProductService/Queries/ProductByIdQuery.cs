namespace Application.Services.ProductService.Queries;

public struct ProductByIdQuery : IRequest<Result<Product>>
{
    public Ulid ProductId { get; set; }
}