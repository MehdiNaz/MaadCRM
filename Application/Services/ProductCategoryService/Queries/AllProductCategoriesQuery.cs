namespace Application.Services.ProductCategoryService.Queries;

public struct AllProductCategoriesQuery : IRequest<Result<ICollection<ProductCategory>>>
{
    public Ulid BusinessId { get; set; }
}