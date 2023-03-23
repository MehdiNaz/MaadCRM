namespace Domain.Models;

public  class Category
{
    public Category()
    {
        InverseIdParrentNavigation = new HashSet<Category>();
        Koupons = new HashSet<Koupon>();
    }

    public int Id { get; set; }
    public int? IdParrent { get; set; }
    public byte? OrderC { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string SeoName { get; set; }
    public byte Show { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }

    public virtual Category IdParrentNavigation { get; set; }
    public virtual ICollection<Category> InverseIdParrentNavigation { get; set; }
    public virtual ICollection<Koupon> Koupons { get; set; }
}