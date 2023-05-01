namespace Domain.Models.Products;

public sealed class ProductCategory : BaseEntityWithUserUpdate
{
    public ProductCategory()
    {
        Id = Ulid.NewUlid();
        ProductCategoryStatus = Status.Show;
        Products = new HashSet<Product>();
    }

    public Ulid Id { get; set; }
    public byte? Order { get; set; }
    public required string ProductCategoryName { get; set; }
    public string Description { get; set; }
    public string? Icon { get; set; }
    public Status ProductCategoryStatus { get; set; }

    public ICollection<Product>? Products { get; set; }

    public Ulid BusinessId { get; set; }
    public Business? Business { get; set; }
}