namespace Application.Services.ProductService.Queries;

public struct ProductBySearchItemQuery : IRequest<ICollection<Product>?>
{
    public string Q { get; set; }
}
