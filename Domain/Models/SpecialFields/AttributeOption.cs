namespace Domain.Models.SpecialFields;

public class AttributeOption : BaseEntity
{
    public AttributeOption()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
        DisplayOrder = 0;
    }

    public Ulid Id { get; set; }
    public required string Title { get; set; }
    public string? ColorSquaresRgb { get; set; }
    public int DisplayOrder { get; set; }
    public StatusType Status { get; set; }
    public Ulid? IdAttribute { get; set; }
    public Attribute IdAttributeNavigation { get; set; }
}