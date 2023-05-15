namespace Domain.Models.SpecialFields;

public class AttributeOption : BaseEntity
{
    public AttributeOption()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
        DisplayOrder = 0;
        AttributeOptionValues = new HashSet<AttributeOptionValue>();
        CustomerAttributes = new HashSet<CustomerAttribute>();
    }

    public Ulid Id { get; set; }
    public required string Title { get; set; }
    public string? ColorSquaresRgb { get; set; }
    public int DisplayOrder { get; set; }
    public StatusType Status { get; set; }
    public Ulid? IdAttribute { get; set; }
    public Attribute IdAttributeNavigation { get; set; }
    public ICollection<AttributeOptionValue>? AttributeOptionValues { get; set; }
    public ICollection<CustomerAttribute>? CustomerAttributes { get; set; }
}