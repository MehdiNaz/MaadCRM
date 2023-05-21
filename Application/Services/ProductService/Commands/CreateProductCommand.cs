using Application.Responses.Product;

namespace Application.Services.ProductService.Commands;

public struct CreateProductCommand : IRequest<Result<ProductResponse>>
{
    public string ProductName { get; set; }
    public Ulid ProductCategoryId { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public decimal? Price { get; set; }
    public decimal? SecondaryPrice { get; set; }
    public decimal? Discount { get; set; }
    public byte? DiscountPercent { get; set; }
    public byte[]? Picture { get; set; }
    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
}