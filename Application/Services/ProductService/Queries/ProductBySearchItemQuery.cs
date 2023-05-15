namespace Application.Services.ProductService.Queries;

public struct ProductBySearchItemQuery : IRequest<Result<ICollection<ProductResponse>>>
{
    public string Q { get; set; }
}
