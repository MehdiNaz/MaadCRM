namespace Application.Services.ProductService.Queries;

public struct AllProductsQuery : IRequest<Result<ICollection<ProductCategoryResponse>>>
{
    public Ulid BusinessId { get; set; }
}