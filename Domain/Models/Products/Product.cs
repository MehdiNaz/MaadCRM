namespace Domain.Models.Products;

public sealed class Product : BaseEntityWithUserUpdate
{
    public Product()
    {
        Id = Ulid.NewUlid();
        StatusPublish = Enum.ProductStatus.Draft;
        StatusTypeProduct = StatusType.Show;
        FavoritesLists = new HashSet<ProductCustomerFavoritesList>();
        CustomerNotes = new HashSet<CustomerNote>();
        ForooshOrders = new HashSet<ForooshOrder>();
        CustomerFeedbacks = new HashSet<CustomerFeedback>();
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
    public StatusType StatusTypeProduct { get; set; }

    public Ulid IdProductCategory { get; set; }
    public ProductCategory ProductCategory { get; set; }

    public ICollection<ProductCustomerFavoritesList>? FavoritesLists { get; set; }
    public ICollection<CustomerNote>? CustomerNotes { get; set; }
    public ICollection<ForooshOrder>? ForooshOrders { get; set; }
    public ICollection<CustomerFeedback>? CustomerFeedbacks { get; set; }
    //public ProductCategory ProductCategory{ get; set; }                                           
    // public virtual ICollection<Visit>? Visits { get; set; }
}