﻿using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Customers;

namespace Domain.Models.SpecialFields;

public class AttributeOptionsValue:BaseEntity
{
    public int ForCustomerId { get; set; }
    public string AttributeDescriptionValue { get; set; }
    public string AttributeXMLValue { get; set; }
    public string AttributeJsonValue { get; set; }
    public int? FileId { get; set; }
    public int? PictureId { get; set; }
    public string FilePath { get; set; }
    public string ImagePath { get; set; }
    public int AttributeOptionId { get; set; }
        
    [ForeignKey(nameof(ForCustomerId))]
    public Customer Customer { get; set; }
    [ForeignKey(nameof(AttributeOptionId))]
    public AttributeOptions AttributeOptions { get; set; }
}