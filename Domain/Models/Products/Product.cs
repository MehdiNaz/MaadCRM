namespace Domain.Models.Products;

public class Product : BaseEntity
{
    public Product()
    {
        Id = Ulid.NewUlid();
        StatusPublish = ProductStatus.Draft;
        StatusProduct = Status.Show;
        FavoritesLists = new HashSet<ProductCustomerFavoritesList>();
        CustomerNotes = new HashSet<CustomerNote>();
        ForooshOrders = new HashSet<ForooshOrder>();
    }

    public Ulid Id { get; set; }
    public string ProductName { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public decimal? Price { get; set; }
    public decimal? SecondaryPrice { get; set; }
    public decimal? Discount { get; set; }
    public byte? DiscountPercent { get; set; }
    public byte[]? Picture { get; set; }
    public ProductStatus StatusPublish { get; set; }
    public Status StatusProduct { get; set; }

    public Ulid IdProductCategory { get; set; }
    public ProductCategory? ProductCategoryIdNavigation { get; set; }

    public virtual ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; set; }
    public virtual ICollection<CustomerNote>? CustomerNotes { get; set; }
    public virtual ICollection<ForooshOrder>? ForooshOrders { get; set; }
}