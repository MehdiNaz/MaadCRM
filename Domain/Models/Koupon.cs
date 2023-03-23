namespace Domain.Models;

public class Koupon
{
    public Koupon()
    {
        Comments = new HashSet<Comment>();
        InverseIdParrentNavigation = new HashSet<Koupon>();
        Orders = new HashSet<Order>();
        Reviews = new HashSet<Review>();
        Visits = new HashSet<Visit>();
    }

    public int Id { get; set; }
    public int? IdParrent { get; set; }
    public int IdCompany { get; set; }
    public int IdCategory { get; set; }
    public short IdBazaryab { get; set; }
    public short IdCity { get; set; }
    public string Title { get; set; }
    public string SeoTitle { get; set; }
    public string Summery { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public decimal? Mablagh { get; set; }
    public decimal? Takhfif { get; set; }
    public byte? TakhfifPercent { get; set; }
    public decimal? Pardakht { get; set; }
    public byte? SpecialOffer { get; set; }
    public string Vizhegiha { get; set; }
    public string SharayeteEstefade { get; set; }
    public string MoshakhasatForooshande { get; set; }
    public byte? Gender { get; set; }
    public byte? Status { get; set; }
    public byte? TakhfifMePerent { get; set; }
    public short? Count { get; set; }
    public short? MinSell { get; set; }
    public short? MinSellPerPerson { get; set; }
    public short? MaxSellPerPerson { get; set; }
    public int? SendTypeid { get; set; }
    public byte? Sub { get; set; }
    public short? ForoushCount { get; set; }
    public string PageTitle { get; set; }
    public string Pagekeywords { get; set; }
    public string Pagedescription { get; set; }
    public string Pageabst { get; set; }
    public short? VisitCount { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }
    public int? IdAgent { get; set; }
    public int? IdAdmin { get; set; }
    public int? Weight { get; set; }
    public byte? SpecialOfferSub { get; set; }
    public byte? SpecialOfferOrder { get; set; }
    public byte? SpecialOfferOrderSub { get; set; }

    // public virtual Bazaryab IdBazaryabNavigation { get; set; }
    public virtual Category IdCategoryNavigation { get; set; }
    public virtual City IdCityNavigation { get; set; }
    public virtual Company IdCompanyNavigation { get; set; }
    public virtual Koupon IdParrentNavigation { get; set; }
    public virtual SendType SendType { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Koupon> InverseIdParrentNavigation { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Visit> Visits { get; set; }
}