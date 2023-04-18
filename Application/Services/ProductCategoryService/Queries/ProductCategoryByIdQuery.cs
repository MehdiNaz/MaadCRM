namespace Application.Services.ProductCategoryService.Queries;

public struct ProductCategoryByIdQuery : IRequest<ProductCategory>
{
    public Ulid ProductCategoryId { get; set; }
}