namespace Application.Services.ProductService.Queries;

public struct ProductBySearchItemQuery : IRequest<Result<ICollection<Product>>>
{
    public string Q { get; set; }
}
