namespace Application.Services.ProductCategoryService.Queries;

public struct GetProductCategoryByIdQuery : IRequest<ProductCategory>
{
    public Ulid ProductCategoryId { get; set; }
}