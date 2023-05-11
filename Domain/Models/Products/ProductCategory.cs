namespace Domain.Models.Products;

public sealed class ProductCategory : BaseEntityWithUserUpdate
{
    public ProductCategory()
    {
        Id = Ulid.NewUlid();
        ProductCategoryStatusType = StatusType.Show;
        Products = new HashSet<Product>();
        Logs = new HashSet<Log>();
    }

    public Ulid Id { get; set; }
    public byte? Order { get; set; }
    public required string ProductCategoryName { get; set; }
    public string Description { get; set; }
    public string? Icon { get; set; }
    public StatusType ProductCategoryStatusType { get; set; }
    public Ulid BusinessId { get; set; }
    public Business? Business { get; set; }

    public ICollection<Product>? Products { get; set; }
    public ICollection<Log>? Logs { get; set; }
}