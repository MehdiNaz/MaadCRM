namespace Application.Services.ProductCategoryService.Queries;

public struct ProductCategoryByIdQuery : IRequest<Result<ProductCategory>>
{
    public Ulid ProductCategoryId { get; set; }
}