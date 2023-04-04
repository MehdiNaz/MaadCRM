﻿namespace Domain.Models.SpecialFields;

public class AttributeOptions : BaseEntity
{
    public AttributeOptions()
    {
        AttributeOptionsId = Ulid.NewUlid();
        AttributeOptionsStatus = Status.Show;
    }

    public Ulid AttributeOptionsId { get; set; }
    public string Title { get; set; }
    public string ColorSquaresRgb { get; set; }
    public Ulid BusinessAttributeId { get; set; }
    public int DisplayOrder { get; set; } = 0;
    public Status AttributeOptionsStatus { get; set; }


    //[ForeignKey(nameof(BusinessAttributeId))]
    public ICollection<Business> Businesses { get; set; }
    public BusinessAttribute BusinessAttribute { get; set; }
    public ICollection<AttributeOptionsValue> AttributeOptionsValues { get; set; }
}