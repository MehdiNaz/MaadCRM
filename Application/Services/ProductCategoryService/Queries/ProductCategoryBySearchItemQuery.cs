namespace Application.Services.ProductCategoryService.Queries;

public struct ProductCategoryBySearchItemQuery : IRequest<ICollection<ProductCategory>>
{
    public string Q { get; set; }
}