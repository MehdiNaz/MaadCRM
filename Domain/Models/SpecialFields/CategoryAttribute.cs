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
    }

    public Ulid CategoryAttributeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public Status CategoryAttributeStatus { get; set; }
    //public Ulid BusinessId { get; set; }


    //[ForeignKey(nameof(BusinessId))]
    //public ICollection<Business> Businesses { get; set; }
    public ICollection<BusinessAttribute>? BusinessAttributes { get; set; }
}