namespace Domain.Models.SpecialFields;

public class AttributeOption : BaseEntity
{
    public AttributeOption()
    {
        AttributeOptionsId = Ulid.NewUlid();
        AttributeOptionsStatus = Status.Show;
        DisplayOrder = 0;
    }

    public Ulid AttributeOptionsId { get; set; }
    public string Title { get; set; }
    public string ColorSquaresRgb { get; set; }
    public Ulid BusinessAttributeId { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid? BusinessId { get; set; }
    public Status AttributeOptionsStatus { get; set; }


    //public Business Business { get; set; }
    //public BusinessAttribute BusinessAttribute { get; set; }
    public ICollection<AttributeOptionsValue>? AttributeOptionsValues { get; set; }
}