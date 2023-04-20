namespace Application.Services.ProductService.Commands;

public struct UpdateProductCommand : IRequest<Product>
{
    public Ulid Id { get; set; }
    public string ProductName { get; set; }
    public Ulid ProductCategoryId { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public decimal? Price { get; set; }
    public decimal? SecondaryPrice { get; set; }
    public decimal? Discount { get; set; }
    public byte? DiscountPercent { get; set; }
    public Ulid FavoritesListId { get; set; }
    public byte[] Picture { get; set; }
}