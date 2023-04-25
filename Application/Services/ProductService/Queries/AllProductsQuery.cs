namespace Application.Services.ProductService.Queries;

public struct AllProductsQuery : IRequest<ICollection<ProductCategoryResponse>>
{
    public Ulid BusinessId { get; set; }
}