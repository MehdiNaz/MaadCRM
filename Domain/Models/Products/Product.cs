namespace Domain.Models.Products;

public class Product : BaseEntity
{
    public Ulid ProductId { get; set; }
    public string ProductName { get; set; }
    public bool Published { get; set; }
    public int Id { get; set; }
    public int? IdParent { get; set; }
    public int IdCompany { get; set; }
    public int IdCategory { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public decimal? Mablagh { get; set; }
    public decimal? Takhfif { get; set; }
    public byte? TakhfifPercent { get; set; }
    public decimal? Pardakht { get; set; }
    public byte? SpecialOffer { get; set; }
    public byte? Status { get; set; }
    public byte? TakhfifMePerent { get; set; }
    public short? MinSell { get; set; }
    public short? MinSellPerPerson { get; set; }
    public short? MaxSellPerPerson { get; set; }
    public Ulid FavoritesListId { get; set; }




    public ICollection<ProductCustomerFavoritesList> FavoritesLists { get; set; }                       //Relation OK




    public virtual Category IdCategoryNavigation { get; set; }
    public virtual Company IdCompanyNavigation { get; set; }
    public virtual Product IdParrentNavigation { get; set; }
    public virtual ICollection<Product> InverseIdParrentNavigation { get; set; }
    // public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Visit> Visits { get; set; }

    public ICollection<Note_Product_Mapping> Note_Product_Mapping { get; set; }
}