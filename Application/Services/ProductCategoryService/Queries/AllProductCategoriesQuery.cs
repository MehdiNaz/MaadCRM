namespace Application.Services.ProductCategoryService.Queries;

public struct AllProductCategoriesQuery : IRequest<ICollection<ProductCategory>>
{
    public Ulid BusinessId { get; set; }
}