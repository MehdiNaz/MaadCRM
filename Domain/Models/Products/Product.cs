namespace Domain.Models.Products;

public class Product : BaseEntity
{
    public Product()
    {
        Id = Ulid.NewUlid();
        PublishStatus = Enum.ProductStatus.Draft;
        ProductStatus = Status.Show;
    }

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
    public byte[]? Picture { get; set; }
    public ProductStatus PublishStatus { get; set; }
    public Status ProductStatus { get; set; }
    public ProductCategory ProductCategory { get; set; }

    public ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; set; }
    public ICollection<ForoshOrder>? ForoshOrders { get; set; }
    //public ProductCategory ProductCategory{ get; set; }                                           
    // public virtual ICollection<Visit>? Visits { get; set; }
}