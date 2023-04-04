using Domain.Models.Customers.Forosh;

namespace Domain.Models.Products;

public class Product : BaseEntity
{
    public Product()
    {
        ProductId = Ulid.NewUlid();
        PublishStatus = Enum.ProductStatus.Draft;
        ProductStatus = Status.Show;
    }

    public Ulid ProductId { get; set; }
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
    public ProductStatus PublishStatus { get; set; }
    public Status ProductStatus { get; set; }


    public ICollection<ProductCustomerFavoritesList> FavoritesLists { get; set; }                       //Relation OK
    public ICollection<ForoshOrder> ForoshOrders { get; set; }                                          //Relation OK
    public ProductCategory ProductCategory{ get; set; }                                                 //Relation OK
    public virtual ICollection<Visit> Visits { get; set; }
}