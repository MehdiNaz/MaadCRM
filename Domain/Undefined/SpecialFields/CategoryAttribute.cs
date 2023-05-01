namespace Domain.Models.SpecialFields;

public class CategoryAttribute : BaseEntity
{
    /// <summary>
    /// salam
    /// </summary>

    public CategoryAttribute()
    {
        CategoryAttributeId = Ulid.NewUlid();
        CategoryAttributeStatus = Status.Show;
        DisplayOrder = 0;
    }

    public Ulid CategoryAttributeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; } 
    public Status CategoryAttributeStatus { get; set; }
    //public Ulid Id { get; set; }


    //[ForeignKey(nameof(Id))]
    //public ICollection<Business> Businesses { get; set; }
    public ICollection<BusinessAttribute>? BusinessAttributes { get; set; }
}