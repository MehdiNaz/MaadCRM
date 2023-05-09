﻿namespace Domain.Models.SpecialFields;

public class AttributeOption : BaseEntity
{
    public AttributeOption()
    {
        AttributeOptionsId = Ulid.NewUlid();
        Status = StatusType.Show;
        DisplayOrder = 0;
    }

    public Ulid AttributeOptionsId { get; set; }
    public required string Title { get; set; }
    public string? ColorSquaresRgb { get; set; }
    public int DisplayOrder { get; set; }
    public StatusType Status { get; set; }
    
    public Ulid? IdAttribute { get; set; }
    public Attribute IdAttributeNavigation { get; set; }

    // public ICollection<AttributeOptionsValue>? AttributeOptionsValues { get; set; }
}