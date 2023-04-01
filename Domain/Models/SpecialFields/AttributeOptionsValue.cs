namespace Domain.Models.SpecialFields;

public class AttributeOptionsValue : BaseEntity
{
    public AttributeOptionsValue()
    {
        AttributeOptionsValueId = Ulid.NewUlid();
    }

    public Ulid AttributeOptionsValueId { get; set; }
    public int ForCustomerId { get; set; }
    public string AttributeDescriptionValue { get; set; }
    public string AttributeXMLValue { get; set; }
    public string AttributeJsonValue { get; set; }
    public int? FileId { get; set; }
    public int? PictureId { get; set; }
    public string FilePath { get; set; }
    public string ImagePath { get; set; }
    public Ulid CustomerId { get; set; }
    public Ulid AttributeOptionId { get; set; }


    //[ForeignKey(nameof(ForCustomerId))]
    public ICollection<Business> Businesses { get; set; }
    public Customer Customer { get; set; }
    //[ForeignKey(nameof(AttributeOptionId))]
    public AttributeOptions AttributeOptions { get; set; }
}