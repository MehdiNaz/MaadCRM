namespace Application.Services.ProductCategoryService.Queries;

public struct ProductCategoryBySearchItemQuery : IRequest<Result<ICollection<ProductCategory>>>
{
    public string Q { get; set; }
}