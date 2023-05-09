namespace Domain.Enum;

public enum AttributeType : byte
{
    [Display(Name = "مشتری")]
    Customer = 1,
    [Display(Name = "مخاطب")]
    Contact = 2,
    [Display(Name = "همکار")]
    TeamMate = 3
}