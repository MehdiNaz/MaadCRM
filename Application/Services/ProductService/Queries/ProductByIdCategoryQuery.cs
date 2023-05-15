namespace Application.Services.ProductService.Queries;

public struct ProductByIdCategoryQuery : IRequest<Result<ICollection<ProductResponse>>>
{
    public Ulid ProductCategoryId { get; set; }
}