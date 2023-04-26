namespace Application.Responses;

public class ProductCategoryResponse
{
    public Ulid ProductId { get; set; }
    public Ulid ProductCategoryId { get; set; }
    public string ProductName { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public decimal? Price { get; set; }
    public decimal? SecondaryPrice { get; set; }
    public decimal? Discount { get; set; }
    public byte? DiscountPercent { get; set; }
    public byte[]? Picture { get; set; }
    public string CategoryName { get; set; }
}