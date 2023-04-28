namespace Application.Services.ProductCategoryService.Queries;

public struct AllProductCategoriesQuery : IRequest<Result<ICollection<ProductCategoryResponse>>>
{
    public Ulid BusinessId { get; set; }
}