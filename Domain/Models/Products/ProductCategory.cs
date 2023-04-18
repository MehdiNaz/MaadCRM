namespace Domain.Models.Products;

public class ProductCategory : BaseEntity
{
    public ProductCategory()
    {
        ProductCategoryId = Ulid.NewUlid();
        ProductCategoryStatus = Status.Show;
    }

    public Ulid ProductCategoryId { get; set; }
    // public Ulid ParentId { get; set; }
    public byte? Order { get; set; }
    public required string ProductCategoryName { get; set; }
    public string Description { get; set; }
    public string? Icon { get; set; }
    public Status ProductCategoryStatus { get; set; }
    public Ulid BusinessId { get; set; }
    public Business Business { get; set; }
    public ICollection<Product> Products { get; set; }
}