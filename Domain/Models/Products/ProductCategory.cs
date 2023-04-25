namespace Domain.Models.Products;

public class ProductCategory : BaseEntity
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

    public virtual ICollection<Product>? Products { get; set; }

    public virtual Ulid BusinessId { get; set; }
    public virtual Business? Business { get; set; }
}